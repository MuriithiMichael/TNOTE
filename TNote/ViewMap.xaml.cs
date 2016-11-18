using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TNote.model;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TNote
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewMap : Page
    {
        NavigationEventArgs args;
        string title, latitude, longitude;

        public ViewMap()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var note = e.Parameter as Note;
            title = note.Title;
            latitude = note.Latitude;
            longitude = note.Longitude;
        }

        private void map_Loaded(object sender, RoutedEventArgs e)
        {
            Geopoint geoPoint = new Geopoint(new BasicGeoposition()
            {
                Latitude = double.Parse(latitude), Longitude = double.Parse(longitude)
            });

            //add center position and zoom level to map
            mcNoteMap.Center = geoPoint;
            mcNoteMap.ZoomLevel = 18;
            // Add map elements
            MapIcon mapIcon = new MapIcon();
            mapIcon.Location = geoPoint;
            mapIcon.Title = title;
            mcNoteMap.MapElements.Add(mapIcon);

        }


    }
}
