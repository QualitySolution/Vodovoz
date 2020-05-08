
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views
{
	public partial class PaymentLoaderView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label1;

		private global::Gtk.FileChooserButton fileChooserBtn;

		private global::Gtk.HBox hbox2;

		private global::Gamma.GtkWidgets.yButton btnReadFile;

		private global::Gtk.ProgressBar progressbar1;

		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gamma.GtkWidgets.yTreeView treeDocuments;

		private global::Gtk.HBox hbox3;

		private global::Gamma.GtkWidgets.yButton btnCancel;

		private global::Gamma.GtkWidgets.yButton btnUpload;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.PaymentLoaderView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.PaymentLoaderView";
			// Container child Vodovoz.Views.PaymentLoaderView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Файл загрузки:");
			this.hbox1.Add(this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.fileChooserBtn = new global::Gtk.FileChooserButton(global::Mono.Unix.Catalog.GetString("Выберите файл"), ((global::Gtk.FileChooserAction)(0)));
			this.fileChooserBtn.Name = "fileChooserBtn";
			this.hbox1.Add(this.fileChooserBtn);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.fileChooserBtn]));
			w2.Position = 1;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnReadFile = new global::Gamma.GtkWidgets.yButton();
			this.btnReadFile.CanFocus = true;
			this.btnReadFile.Name = "btnReadFile";
			this.btnReadFile.UseUnderline = true;
			this.btnReadFile.Label = global::Mono.Unix.Catalog.GetString("Прочитать данные из файла");
			this.hbox2.Add(this.btnReadFile);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.btnReadFile]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.progressbar1 = new global::Gtk.ProgressBar();
			this.progressbar1.Name = "progressbar1";
			this.hbox2.Add(this.progressbar1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.progressbar1]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 1;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			this.treeDocuments = new global::Gamma.GtkWidgets.yTreeView();
			this.treeDocuments.CanFocus = true;
			this.treeDocuments.Name = "treeDocuments";
			this.scrolledwindow1.Add(this.treeDocuments);
			this.vbox1.Add(this.scrolledwindow1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.scrolledwindow1]));
			w8.Position = 3;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnCancel = new global::Gamma.GtkWidgets.yButton();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString("Отмена");
			this.hbox3.Add(this.btnCancel);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.btnCancel]));
			w9.PackType = ((global::Gtk.PackType)(1));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnUpload = new global::Gamma.GtkWidgets.yButton();
			this.btnUpload.CanFocus = true;
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.UseUnderline = true;
			this.btnUpload.Label = global::Mono.Unix.Catalog.GetString("Загрузить");
			global::Gtk.Image w10 = new global::Gtk.Image();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-goto-bottom", global::Gtk.IconSize.Menu);
			this.btnUpload.Image = w10;
			this.hbox3.Add(this.btnUpload);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.btnUpload]));
			w11.PackType = ((global::Gtk.PackType)(1));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox1.Add(this.hbox3);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
			w12.Position = 4;
			w12.Expand = false;
			w12.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
