
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ViewWidgets.JournalActions
{
	public partial class ComplaintsJournalActionsView
	{
		private global::Gamma.GtkWidgets.yHBox yhboxBtns;

		private global::Gamma.GtkWidgets.yHBox hboxDefaultBtns;

		private global::Gtk.VSeparator vseparator1;

		private global::Gamma.GtkWidgets.yButton btnOpenReport;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ViewWidgets.JournalActions.ComplaintsJournalActionsView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ViewWidgets.JournalActions.ComplaintsJournalActionsView";
			// Container child Vodovoz.ViewWidgets.JournalActions.ComplaintsJournalActionsView.Gtk.Container+ContainerChild
			this.yhboxBtns = new global::Gamma.GtkWidgets.yHBox();
			this.yhboxBtns.Name = "yhboxBtns";
			this.yhboxBtns.Spacing = 6;
			// Container child yhboxBtns.Gtk.Box+BoxChild
			this.hboxDefaultBtns = new global::Gamma.GtkWidgets.yHBox();
			this.hboxDefaultBtns.Name = "hboxDefaultBtns";
			this.hboxDefaultBtns.Spacing = 6;
			this.yhboxBtns.Add(this.hboxDefaultBtns);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.yhboxBtns[this.hboxDefaultBtns]));
			w1.Position = 0;
			// Container child yhboxBtns.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.yhboxBtns.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.yhboxBtns[this.vseparator1]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child yhboxBtns.Gtk.Box+BoxChild
			this.btnOpenReport = new global::Gamma.GtkWidgets.yButton();
			this.btnOpenReport.CanFocus = true;
			this.btnOpenReport.Name = "btnOpenReport";
			this.btnOpenReport.UseUnderline = true;
			this.btnOpenReport.Label = global::Mono.Unix.Catalog.GetString("Открыть печатную форму");
			this.yhboxBtns.Add(this.btnOpenReport);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.yhboxBtns[this.btnOpenReport]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.Add(this.yhboxBtns);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
