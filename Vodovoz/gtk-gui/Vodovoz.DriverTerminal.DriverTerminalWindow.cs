
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.DriverTerminal
{
	public partial class DriverTerminalWindow
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label labelRL;

		private global::Gamma.Widgets.yValidatedEntry entryRouteListNumber;

		private global::Gtk.Button btnPrintRouteList;

		private global::Gtk.Button btnPrintLoadDocument;

		private global::Gtk.Button btnPrintRouteMap;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button buttonClear;

		private global::Gtk.HBox hboxViewer;

		private global::Gtk.Statusbar statusbarMain;

		private global::Gtk.Label labelUser;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.DriverTerminal.DriverTerminalWindow
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
			this.UIManager.InsertActionGroup(w1, 0);
			this.AddAccelGroup(this.UIManager.AccelGroup);
			this.Name = "Vodovoz.DriverTerminal.DriverTerminalWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("DriverTerminalWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child Vodovoz.DriverTerminal.DriverTerminalWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelRL = new global::Gtk.Label();
			this.labelRL.Name = "labelRL";
			this.labelRL.LabelProp = global::Mono.Unix.Catalog.GetString("Номер МЛ");
			this.hbox1.Add(this.labelRL);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelRL]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryRouteListNumber = new global::Gamma.Widgets.yValidatedEntry();
			this.entryRouteListNumber.CanFocus = true;
			this.entryRouteListNumber.Name = "entryRouteListNumber";
			this.entryRouteListNumber.IsEditable = true;
			this.entryRouteListNumber.InvisibleChar = '●';
			this.hbox1.Add(this.entryRouteListNumber);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.entryRouteListNumber]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnPrintRouteList = new global::Gtk.Button();
			this.btnPrintRouteList.CanFocus = true;
			this.btnPrintRouteList.Name = "btnPrintRouteList";
			this.btnPrintRouteList.UseUnderline = true;
			this.btnPrintRouteList.Label = global::Mono.Unix.Catalog.GetString("Маршрутный лист");
			this.hbox1.Add(this.btnPrintRouteList);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnPrintRouteList]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnPrintLoadDocument = new global::Gtk.Button();
			this.btnPrintLoadDocument.CanFocus = true;
			this.btnPrintLoadDocument.Name = "btnPrintLoadDocument";
			this.btnPrintLoadDocument.UseUnderline = true;
			this.btnPrintLoadDocument.Label = global::Mono.Unix.Catalog.GetString("Талон погрузки");
			this.hbox1.Add(this.btnPrintLoadDocument);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnPrintLoadDocument]));
			w5.Position = 3;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnPrintRouteMap = new global::Gtk.Button();
			this.btnPrintRouteMap.CanFocus = true;
			this.btnPrintRouteMap.Name = "btnPrintRouteMap";
			this.btnPrintRouteMap.UseUnderline = true;
			this.btnPrintRouteMap.Label = global::Mono.Unix.Catalog.GetString("Карта маршрута");
			this.hbox1.Add(this.btnPrintRouteMap);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnPrintRouteMap]));
			w6.Position = 4;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonClear = new global::Gtk.Button();
			this.buttonClear.CanFocus = true;
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.UseUnderline = true;
			this.buttonClear.Label = global::Mono.Unix.Catalog.GetString("Очистить");
			this.hbox2.Add(this.buttonClear);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonClear]));
			w7.PackType = ((global::Gtk.PackType)(1));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			this.hbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.hbox2]));
			w8.Position = 5;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hboxViewer = new global::Gtk.HBox();
			this.hboxViewer.Name = "hboxViewer";
			this.hboxViewer.Spacing = 6;
			this.vbox1.Add(this.hboxViewer);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hboxViewer]));
			w10.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.statusbarMain = new global::Gtk.Statusbar();
			this.statusbarMain.Name = "statusbarMain";
			this.statusbarMain.Spacing = 6;
			// Container child statusbarMain.Gtk.Box+BoxChild
			this.labelUser = new global::Gtk.Label();
			this.labelUser.Name = "labelUser";
			this.statusbarMain.Add(this.labelUser);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.statusbarMain[this.labelUser]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox1.Add(this.statusbarMain);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.statusbarMain]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 790;
			this.DefaultHeight = 396;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.btnPrintRouteList.Clicked += new global::System.EventHandler(this.OnBtnPrintRouteListClicked);
			this.btnPrintLoadDocument.Clicked += new global::System.EventHandler(this.OnBtnPrintLoadDocumentClicked);
			this.btnPrintRouteMap.Clicked += new global::System.EventHandler(this.OnBtnPrintRouteMapClicked);
			this.buttonClear.Clicked += new global::System.EventHandler(this.OnButtonClearClicked);
		}
	}
}
