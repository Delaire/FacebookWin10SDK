# FacebookWin10SDK

Example on how to use the new Facebook login: http://damiendelaire.blogspot.com/2015/11/using-new-facebook-sdk-in-windows-10.html

Quick example:

```C#
  public async Task<string> LogIntoFacebook()
        {
            //getting application Id
            string SID = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();

            // Get active session
            FBSession sess = FBSession.ActiveSession;
            sess.FBAppId = Dailymotion.Core.Constants.FacebookAppId;
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
```
