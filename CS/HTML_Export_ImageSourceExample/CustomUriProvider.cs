#region #usings
using DevExpress.Office.Services;
using DevExpress.Office.Utils;
using System;
#endregion #usings

namespace HTML_Export_ImageSourceExample {
    #region #customuriprovider
    public class CustomUriProvider : IUriProvider {
        #region IUriProvider Members
        public string CreateCssUri(string rootUri, string styleText, string relativeUri) {
            return String.Empty;
        }

        public string CreateImageUri(string rootUri, OfficeImage image, string relativeUri) {
            return image.Uri;
        }
        #endregion
    }
    #endregion #customuriprovider
}
