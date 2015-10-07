using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Casting;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyUniversalApp
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DevicePicker picker;
        DeviceInformation activeDevice = null;
        int thisViewId;
        public MainPage()
        {
            this.InitializeComponent();
            thisViewId = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Id;
            // Instantiate the Device Picker
            picker = new DevicePicker();

            // Get the device selecter for Miracast devices
            picker.Filter.SupportedDeviceSelectors.Add(ProjectionManager.GetDeviceSelector());

            //Hook up device selected event
            picker.DeviceSelected += Picker_DeviceSelected;

            //Hook up device disconnected event
            picker.DisconnectButtonClicked += Picker_DisconnectButtonClicked;

            //Hook up picker dismissed event
            picker.DevicePickerDismissed += Picker_DevicePickerDismissed;

            picker.Show(new Rect(this.ActualWidth, this.ActualHeight , this.ActualWidth, this.ActualHeight), Windows.UI.Popups.Placement.Above);
        }

        private async void Picker_DeviceSelected(DevicePicker sender, DeviceSelectedEventArgs args)
        {
            //Casting must occur from the UI thread.  This dispatches the casting calls to the UI thread.
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                try
                {
                    // Set status to Connecting
                    picker.SetDisplayStatus(args.SelectedDevice, "Connecting", DevicePickerDisplayStatusOptions.ShowProgress);

                    // Getting the selected device improves debugging
                    DeviceInformation selectedDevice = args.SelectedDevice;
                    try
                    {
                        await ProjectionManager.StartProjectingAsync(ApplicationView.GetApplicationViewIdForWindow(CoreWindow.GetForCurrentThread()), thisViewId, selectedDevice);

                    }
                    catch (Exception ex)
                    {
                        if (!ProjectionManager.ProjectionDisplayAvailable)
                            throw ex;
                    }

                    try
                    {
                        
                            activeDevice = selectedDevice;
                        
                            // Set status to Connected
                            picker.SetDisplayStatus(args.SelectedDevice, "Connected", DevicePickerDisplayStatusOptions.ShowDisconnectButton);
                            picker.Hide();
                    }
                    catch (Exception)
                    {
                        try { picker.SetDisplayStatus(args.SelectedDevice, "Connection Failed", DevicePickerDisplayStatusOptions.ShowRetryButton); } catch { }
                    }
                }
                catch (Exception ex)
                {
                    
                }
            });
        }
        private async void Picker_DevicePickerDismissed(DevicePicker sender, object args)
        {
            ////Casting must occur from the UI thread.  This dispatches the casting calls to the UI thread.
            //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            //{
            //    if (activeDevice == null)
            //    {
            //        player.Play();
            //    }
            //});
        }
        private async void Picker_DisconnectButtonClicked(DevicePicker sender, DeviceDisconnectButtonClickedEventArgs args)
        {
            ////Casting must occur from the UI thread.  This dispatches the casting calls to the UI thread.
            //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            //{
            //    rootPage.NotifyUser("Disconnect Button clicked", NotifyType.StatusMessage);
            //    //Update the display status for the selected device.
            //    sender.SetDisplayStatus(args.Device, "Disconnecting", DevicePickerDisplayStatusOptions.ShowProgress);

            //    if (this.pvb.ProjectedPage != null)
            //        this.pvb.ProjectedPage.StopProjecting();

            //    //Update the display status for the selected device.
            //    sender.SetDisplayStatus(args.Device, "Disconnected", DevicePickerDisplayStatusOptions.None);
            //    rootPage.NotifyUser("Disconnected", NotifyType.StatusMessage);

            //    // Set the active device variables to null
            //    activeDevice = null;
            //});
        }

       

    }
}
