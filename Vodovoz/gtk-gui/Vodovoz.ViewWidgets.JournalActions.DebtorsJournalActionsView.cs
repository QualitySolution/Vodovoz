
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ViewWidgets.JournalActions
{
	public partial class DebtorsJournalActionsView
	{
		private global::Gamma.GtkWidgets.yVBox vboxMain;

		private global::Gamma.GtkWidgets.yHBox hboxBtns;

		private global::Gamma.GtkWidgets.yButton ybtnCreateTasks;

		private global::Gamma.GtkWidgets.yButton ybtnSummaryBottlesAndDepositsReport;

		private global::Gamma.GtkWidgets.yButton ybtnOpenPrintingForm;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ViewWidgets.JournalActions.DebtorsJournalActionsView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ViewWidgets.JournalActions.DebtorsJournalActionsView";
			// Container child Vodovoz.ViewWidgets.JournalActions.DebtorsJournalActionsView.Gtk.Container+ContainerChild
			this.vboxMain = new global::Gamma.GtkWidgets.yVBox();
			this.vboxMain.Name = "vboxMain";
			this.vboxMain.Spacing = 6;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hboxBtns = new global::Gamma.GtkWidgets.yHBox();
			this.hboxBtns.Name = "hboxBtns";
			this.hboxBtns.Spacing = 6;
			// Container child hboxBtns.Gtk.Box+BoxChild
			this.ybtnCreateTasks = new global::Gamma.GtkWidgets.yButton();
			this.ybtnCreateTasks.CanFocus = true;
			this.ybtnCreateTasks.Name = "ybtnCreateTasks";
			this.ybtnCreateTasks.UseUnderline = true;
			this.ybtnCreateTasks.Label = global::Mono.Unix.Catalog.GetString("Создать задачи");
			this.hboxBtns.Add(this.ybtnCreateTasks);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hboxBtns[this.ybtnCreateTasks]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hboxBtns.Gtk.Box+BoxChild
			this.ybtnSummaryBottlesAndDepositsReport = new global::Gamma.GtkWidgets.yButton();
			this.ybtnSummaryBottlesAndDepositsReport.CanFocus = true;
			this.ybtnSummaryBottlesAndDepositsReport.Name = "ybtnSummaryBottlesAndDepositsReport";
			this.ybtnSummaryBottlesAndDepositsReport.UseUnderline = true;
			this.ybtnSummaryBottlesAndDepositsReport.Label = global::Mono.Unix.Catalog.GetString("Акт по бутылям и залогам");
			this.hboxBtns.Add(this.ybtnSummaryBottlesAndDepositsReport);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxBtns[this.ybtnSummaryBottlesAndDepositsReport]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hboxBtns.Gtk.Box+BoxChild
			this.ybtnOpenPrintingForm = new global::Gamma.GtkWidgets.yButton();
			this.ybtnOpenPrintingForm.CanFocus = true;
			this.ybtnOpenPrintingForm.Name = "ybtnOpenPrintingForm";
			this.ybtnOpenPrintingForm.UseUnderline = true;
			this.ybtnOpenPrintingForm.Label = global::Mono.Unix.Catalog.GetString("Печатная форма");
			this.hboxBtns.Add(this.ybtnOpenPrintingForm);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hboxBtns[this.ybtnOpenPrintingForm]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.vboxMain.Add(this.hboxBtns);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.hboxBtns]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			this.Add(this.vboxMain);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
