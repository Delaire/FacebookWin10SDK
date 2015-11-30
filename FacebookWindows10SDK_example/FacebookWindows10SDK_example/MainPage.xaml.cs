using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Facebook;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FacebookWindows10SDK_example
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // Add permissions required by the app 
        private static readonly List<string> PermissionList = new List<String>() { "user_about_me", "email", "publish_actions" };



        public async Task<string> LogIntoFacebook()
        {
            //getting application Id
            string SID = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();

            // Get active session
            FBSession sess = FBSession.ActiveSession;
            sess.FBAppId = Constants.FacebookAppId;
            sess.WinAppId = SID;

            //setting Permissions
            FBPermissions permissions = new FBPermissions(PermissionList);

            try
            {
                // Login to Facebook
                FBResult result = await sess.LoginAsync(permissions);

                if (result.Succeeded)
                {
                    // Login successful
                    return sess.AccessTokenData.AccessToken;
                }
                else
                {
                    // Login failed
                    return null;

                }
            }
            catch (InvalidOperationException ex)
            {
                //error handling
                return null;
            }
            catch (Exception ex)
            {
                //error handling
                return null;
            }
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //get the access token to login
            var result = await LogIntoFacebook();
        }
    }
}
