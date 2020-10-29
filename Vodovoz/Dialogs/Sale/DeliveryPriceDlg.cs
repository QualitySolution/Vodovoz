﻿using System;
using System.Globalization;
using GMap.NET;
using GMap.NET.GtkSharp;
using GMap.NET.GtkSharp.Markers;
using GMap.NET.MapProviders;
using QS.Dialog.GtkUI;
using QS.Osm.DTO;
using Vodovoz.Additions.Logistic;
using Vodovoz.Domain.Client;
using Vodovoz.Tools.Logistic;

namespace Vodovoz.Dialogs.Sale
{
	public partial class DeliveryPriceDlg : QS.Dialog.Gtk.TdiTabBase
	{
		private Gtk.Clipboard clipboard = Gtk.Clipboard.Get(Gdk.Atom.Intern("CLIPBOARD", false));
	
		readonly GMapOverlay addressOverlay = new GMapOverlay();
		GMapMarker addressMarker;
		decimal? latitude;
		decimal? longitude;

		public DeliveryPriceDlg()
		{
			this.Build();

			TabName = "Расчет стоимости доставки";

			entryCity.CitySelected += (sender, e) => {
				entryBuilding.House = string.Empty;
				entryStreet.CityId = entryCity.OsmId;
				entryStreet.Street = string.Empty;
				entryStreet.StreetDistrict = string.Empty;
			};

			entryStreet.StreetSelected += (sender, e) => {
				entryBuilding.Street = new OsmStreet(-1, entryStreet.CityId, entryStreet.Street, entryStreet.StreetDistrict);
			};

			entryBuilding.CompletionLoaded += EntryBuilding_Changed;
			entryBuilding.Changed += EntryBuilding_Changed;

			//Configure map
			MapWidget.MapProvider = GMapProviders.YandexMap;
			MapWidget.Position = new PointLatLng(59.93900, 30.31646);
			MapWidget.MinZoom = 0;
			MapWidget.MaxZoom = 24;
			MapWidget.Zoom = 9;
			MapWidget.WidthRequest = 450;
			MapWidget.HasFrame = true;
			MapWidget.Overlays.Add(addressOverlay);

			yenumcomboMapType.ItemsEnum = typeof(MapProviders);
			yenumcomboMapType.ChangedByUser += (sender, e) => MapWidget.MapProvider = MapProvidersHelper.GetPovider((MapProviders)yenumcomboMapType.SelectedItem);
		}

		public DeliveryPriceDlg(DeliveryPoint deliveryPoint) : this()
		{
			SetCoordinates(deliveryPoint.Latitude, deliveryPoint.Longitude);
			deliverypriceview.DeliveryPrice = DeliveryPriceCalculator.Calculate(latitude, longitude, yspinBottles.ValueAsInt);
		}
		void EntryBuilding_Changed(object sender, EventArgs e)
		{
			if(entryBuilding.OsmCompletion.HasValue && entryBuilding.OsmCompletion.Value) {
				entryBuilding.GetCoordinates(out decimal? lng, out decimal? lat);
				SetCoordinates(lat, lng);
				deliverypriceview.DeliveryPrice = DeliveryPriceCalculator.Calculate(latitude, longitude, yspinBottles.ValueAsInt);
			}
		}

		protected void OnButtonInsertFromBufferClicked(object sender, EventArgs e)
		{
			bool error = true;

			string booferCoordinates = clipboard.WaitForText();

			string[] coordinates = booferCoordinates?.Split(',');
			if(coordinates?.Length == 2) {
				bool goodLat = decimal.TryParse(coordinates[0].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out decimal lat);
				bool goodLon = decimal.TryParse(coordinates[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out decimal lng);
				SetCoordinates(lat, lng);

				if(goodLat && goodLon) {
					deliverypriceview.DeliveryPrice = DeliveryPriceCalculator.Calculate(latitude, longitude, yspinBottles.ValueAsInt);
					error = false;
				}
			}
			if(error)
				MessageDialogHelper.RunErrorDialog(
					"Буфер обмена не содержит координат или содержит неправильные координаты");
		}

		private void SetCoordinates(decimal? lat, decimal? lng)
		{
			latitude = lat;
			longitude = lng;

			if(addressMarker != null) {
				addressOverlay.Markers.Clear();
				addressMarker = null;
			}

			if(latitude.HasValue && longitude.HasValue) {
				addressMarker = new GMarkerGoogle(new PointLatLng((double)latitude.Value, (double)longitude.Value),
					GMarkerGoogleType.arrow);
				addressOverlay.Markers.Add(addressMarker);

				var position = new PointLatLng((double)latitude.Value, (double)longitude.Value);
				MapWidget.Position = position;
				MapWidget.Zoom = 15;

				ylabelFoundOnOsm.LabelProp = String.Format("(ш. {0:F5}, д. {1:F5})", latitude, longitude);
			}
			else
			{
				MapWidget.Position = new PointLatLng(59.93900, 30.31646);
				MapWidget.Zoom = 9;
				ylabelFoundOnOsm.LabelProp = "нет координат";
			}
		}

		protected void OnYspinBottlesValueChanged(object sender, EventArgs e)
		{
			deliverypriceview.DeliveryPrice = DeliveryPriceCalculator.Calculate(latitude, longitude, yspinBottles.ValueAsInt);
		}
	}
}
