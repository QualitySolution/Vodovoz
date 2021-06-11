﻿using System;
using System.Linq;
using QS.Views.GtkUI;
using Vodovoz.ViewModels.Dialogs.Orders;
using Gamma.ColumnConfig;
using Gamma.GtkWidgets;
using Vodovoz.Domain.Orders;
using Gtk;
using QS.Dialog.GtkUI;
using QS.Project.Dialogs;
using QS.Project.Dialogs.GtkUI;
using Vodovoz.Domain.Goods;
using Vodovoz.Infrastructure.Converters;
using Vodovoz.JournalFilters;
using Vodovoz.ViewModel;

namespace Vodovoz.ViewWidgets.Orders
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class OrderMovementItemsView : WidgetViewBase<OrderMovementItemsViewModel>
    {
        public OrderMovementItemsView(OrderMovementItemsViewModel viewModel) : base(viewModel)
        {
            this.Build();
            Configure();
        }

        private void Configure()
        {
            ybtnAddMovementItemToClient.Clicked += 
                (sender, args) => ViewModel.AddMovementItemToClientCommand.Execute();
            ybtnAddMovementItemFromClient.Clicked +=
                (sender, args) => ViewModel.AddMovementItemFromClientCommand.Execute(); 
            ybtnRemoveMovementItem.Sensitive = false;
            ViewModel.Order.ObservableOrderMovements.ElementAdded += Order_ObservableOrderEquipments_ElementAdded;

            /*if (MyTab is OrderReturnsView)
            {
                SetColumnConfigForReturnView();
                ylblTitle.Visible = false;
            }
            else*/
                SetColumnConfigForOrderItemsView();

            ytreeViewMovementItems.ItemsDataSource = ViewModel.Order.ObservableOrderMovements;
            ytreeViewMovementItems.Selection.Changed += TreeEquipment_Selection_Changed;
            ytreeViewMovementItems.Binding.AddBinding(ViewModel, vm => vm.CanEditMovementItems, w => w.Sensitive).InitializeFromSource();
        }

        public event EventHandler<OrderEquipment> OnDeleteEquipment;

        /// <summary>
        /// Ширина первой колонки списка оборудования (создано для храннения 
        /// ширины колонки до автосайза ячейки по содержимому, чтобы отобразить
        /// по правильному положению ввод количества при добавлении нового товара)
        /// </summary>
        int treeAnyGoodsFirstColWidth;

        public void UnsubscribeOnEquipmentAdd()
        {
            ViewModel.Order.ObservableOrderMovements.ElementAdded -= Order_ObservableOrderEquipments_ElementAdded;
        }
        
        private void SetColumnConfigForOrderItemsView()
        {
            var colorBlack = new Gdk.Color(0, 0, 0);
            var colorBlue = new Gdk.Color(0, 0, 0xff);
            var colorGreen = new Gdk.Color(0, 0xff, 0);
            var colorWhite = new Gdk.Color(0xff, 0xff, 0xff);
            var colorLightYellow = new Gdk.Color(0xe1, 0xd6, 0x70);
            var colorLightRed = new Gdk.Color(0xff, 0x66, 0x66);

            ytreeViewMovementItems.ColumnsConfig = FluentColumnsConfig<OrderEquipment>.Create()
                .AddColumn("Наименование").SetDataProperty(node => node.FullNameString)
                .AddColumn("Направление").SetDataProperty(node => node.DirectionString)
                .AddColumn("Кол-во")
                .AddNumericRenderer(node => node.Count).WidthChars(10)
                .Adjustment(new Adjustment(0, 0, 1000000, 1, 100, 0))
                .AddSetter((cell, node) => {
                    cell.Editable = !(node.OrderItem != null && node.OwnType == OwnTypes.Rent);
                })
                .AddTextRenderer(node => $"({node.ReturnedCount})")
                .AddColumn("Принадлежность").AddEnumRenderer(node => node.OwnType, true, new Enum[] { OwnTypes.None })
                .AddSetter((c, n) => {
                    c.Editable = false;
                    c.Editable = n.Nomenclature?.Category == NomenclatureCategory.equipment;
                })
                .AddSetter((c, n) => {
                    c.BackgroundGdk = colorWhite;
                    if (n.Nomenclature?.Category == NomenclatureCategory.equipment
                      && n.OwnType == OwnTypes.None)
                    {
                        c.BackgroundGdk = colorLightRed;
                    }
                })
                .AddColumn("Причина").AddEnumRenderer(
                    node => node.DirectionReason
                    , true
                ).AddSetter((c, n) => {
                    if (n.Direction == Domain.Orders.Direction.Deliver)
                    {
                        switch (n.DirectionReason)
                        {
                            case DirectionReason.Rent:
                                c.Text = "В аренду";
                                break;
                            case DirectionReason.Repair:
                                c.Text = "Из ремонта";
                                break;
                            case DirectionReason.Cleaning:
                                c.Text = "После санобработки";
                                break;
                            case DirectionReason.RepairAndCleaning:
                                c.Text = "Из ремонта и санобработки";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (n.DirectionReason)
                        {
                            case DirectionReason.Rent:
                                c.Text = "Закрытие аренды";
                                break;
                            case DirectionReason.Repair:
                                c.Text = "В ремонт";
                                break;
                            case DirectionReason.Cleaning:
                                c.Text = "На санобработку";
                                break;
                            case DirectionReason.RepairAndCleaning:
                                c.Text = "В ремонт и санобработку";
                                break;
                            default:
                                break;
                        }
                    }
                }).HideCondition(ViewModel.HideItemFromDirectionReasonComboInEquipment)
                .AddSetter((c, n) => {
                    c.Editable = false;
                    c.Editable =
                         n.Nomenclature?.Category == NomenclatureCategory.equipment
                         && n.Reason != Reason.Rent
                         && n.OwnType != OwnTypes.Duty
                         && n.Nomenclature?.SaleCategory != SaleCategory.forSale;
                })
                .AddSetter((c, n) => {
                    c.BackgroundGdk = (n.Nomenclature?.Category == NomenclatureCategory.equipment
                                       && n.DirectionReason == DirectionReason.None
                                       && n.OwnType != OwnTypes.Duty
                                       && n.Nomenclature?.SaleCategory != SaleCategory.forSale)
                        ? colorLightRed
                        : colorWhite;
                })
                .AddColumn("")
                .Finish();
        }

        private void SetColumnConfigForReturnView()
        {
            var colorBlack = new Gdk.Color(0, 0, 0);
            var colorBlue = new Gdk.Color(0, 0, 0xff);
            var colorGreen = new Gdk.Color(0, 0xff, 0);
            var colorWhite = new Gdk.Color(0xff, 0xff, 0xff);
            var colorLightYellow = new Gdk.Color(0xe1, 0xd6, 0x70);
            var colorLightRed = new Gdk.Color(0xff, 0x66, 0x66);

            ytreeViewMovementItems.ColumnsConfig = FluentColumnsConfig<OrderEquipment>.Create()
                .AddColumn("Наименование").SetDataProperty(node => node.FullNameString)
                .AddColumn("Направление").SetDataProperty(node => node.DirectionString)
                .AddColumn("Кол-во(недовоз)")
                .AddNumericRenderer(node => node.Count).WidthChars(10)
                .Adjustment(new Adjustment(0, 0, 1000000, 1, 100, 0)).Editing(false)
                .AddTextRenderer(node => $"({node.ReturnedCount})")
                .AddColumn("Кол-во по факту")
                    .AddNumericRenderer(node => node.ActualCount, new NullValueToZeroConverter(), false)
                    .AddSetter((cell, node) => {
                        cell.Editable = false;
                        foreach (var cat in Nomenclature.GetCategoriesForGoods())
                        {
                            if (cat == node.Nomenclature.Category)
                                cell.Editable = true;
                        }
                    })
                    .Adjustment(new Gtk.Adjustment(0, 0, 9999, 1, 1, 0))
                    .AddTextRenderer(node => node.Nomenclature.Unit == null ? string.Empty : node.Nomenclature.Unit.Name, false)
                //.AddColumn("Забрано у клиента")
                //.AddToggleRenderer(node => node.IsDelivered).Editing(false)
                .AddColumn("Причина незабора").AddTextRenderer(x => x.ConfirmedComment)
                .AddSetter((cell, node) => cell.Editable = node.Direction == Domain.Orders.Direction.PickUp)
                .AddColumn("Принадлежность").AddEnumRenderer(node => node.OwnType, true, new Enum[] { OwnTypes.None })
                .AddSetter((c, n) => {
                    c.Editable = false;
                    c.Editable = n.Nomenclature?.Category == NomenclatureCategory.equipment;
                })
                .AddSetter((c, n) => {
                    c.BackgroundGdk = colorWhite;
                    if (n.Nomenclature?.Category == NomenclatureCategory.equipment
                      && n.OwnType == OwnTypes.None)
                    {
                        c.BackgroundGdk = colorLightRed;
                    }
                })
                .AddColumn("Причина").AddEnumRenderer(
                    node => node.DirectionReason,
                    true
                ).AddSetter((c, n) => {
                    if (n.Direction == Domain.Orders.Direction.Deliver)
                    {
                        switch (n.DirectionReason)
                        {
                            case DirectionReason.Rent:
                                c.Text = "В аренду";
                                break;
                            case DirectionReason.Repair:
                                c.Text = "Из ремонта";
                                break;
                            case DirectionReason.Cleaning:
                                c.Text = "После санобработки";
                                break;
                            case DirectionReason.RepairAndCleaning:
                                c.Text = "Из ремонта и санобработки";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (n.DirectionReason)
                        {
                            case DirectionReason.Rent:
                                c.Text = "Закрытие аренды";
                                break;
                            case DirectionReason.Repair:
                                c.Text = "В ремонт";
                                break;
                            case DirectionReason.Cleaning:
                                c.Text = "На санобработку";
                                break;
                            case DirectionReason.RepairAndCleaning:
                                c.Text = "В ремонт и санобработку";
                                break;
                            default:
                                break;
                        }
                    }
                }).HideCondition(ViewModel.HideItemFromDirectionReasonComboInEquipment)
                .AddSetter((c, n) => {
                    c.Editable = false;
                    c.Editable =
                        n.Nomenclature?.Category == NomenclatureCategory.equipment
                         && n.Reason != Reason.Rent
                         && n.OwnType != OwnTypes.Duty
                         && n.Nomenclature?.SaleCategory != SaleCategory.forSale;
                })
                .AddSetter((c, n) => {
                    c.BackgroundGdk = (n.Nomenclature?.Category == NomenclatureCategory.equipment
                                       && n.DirectionReason == DirectionReason.None
                                       && n.OwnType != OwnTypes.Duty
                                       && n.Nomenclature?.SaleCategory != SaleCategory.forSale)
                        ? colorLightRed
                        : colorWhite;
                })
                .AddColumn("")
                .Finish();
        }

        void TreeEquipment_Selection_Changed(object sender, EventArgs e)
        {
            object[] items = ytreeViewMovementItems.GetSelectedObjects();

            if (!items.Any())
                return;

            ybtnRemoveMovementItem.Sensitive = items.Any();
        }

        void Order_ObservableOrderEquipments_ElementAdded(object aList, int[] aIdx)
        {
            treeAnyGoodsFirstColWidth = ytreeViewMovementItems.Columns.First(x => x.Title == "Наименование").Width;
            ytreeViewMovementItems.ExposeEvent += TreeAnyGoods_ExposeEvent;
            //Выполнение в случае если размер не поменяется
            EditGoodsCountCellOnAdd(ytreeViewMovementItems);
        }

        void TreeAnyGoods_ExposeEvent(object o, ExposeEventArgs args)
        {
            var newColWidth = ((yTreeView)o).Columns.First().Width;
            if (treeAnyGoodsFirstColWidth != newColWidth)
            {
                EditGoodsCountCellOnAdd((yTreeView)o);
                ((yTreeView)o).ExposeEvent -= TreeAnyGoods_ExposeEvent;
            }
        }

        /// <summary>
        /// Активирует редактирование ячейки количества
        /// </summary>
        private void EditGoodsCountCellOnAdd(yTreeView treeView)
        {
            int index = treeView.Model.IterNChildren() - 1;
            TreePath path;

            treeView.Model.IterNthChild(out TreeIter iter, index);
            path = treeView.Model.GetPath(iter);

            var column = treeView.Columns.First(x => x.Title == /*(MyTab is OrderReturnsView ? "Кол-во(недовоз)" : */"Кол-во")/*)*/;
            var renderer = column.CellRenderers.First();
            Application.Invoke(delegate {
                treeView.SetCursorOnCell(path, column, renderer, true);
            });
            treeView.GrabFocus();
        }

        protected void OnButtonDeleteEquipmentClicked(object sender, EventArgs e)
        {
            if (ytreeViewMovementItems.GetSelectedObject() is OrderEquipment deletedEquipment)
            {
                OnDeleteEquipment?.Invoke(this, deletedEquipment);
                //при удалении номенклатуры выделение снимается и при последующем удалении exception
                //для исправления делаем кнопку удаления не активной, если объект не выделился в списке
                ybtnRemoveMovementItem.Sensitive = ytreeViewMovementItems.GetSelectedObject() != null;
            }
        }
    }
}