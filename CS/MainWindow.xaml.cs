using System;
using System.Windows;
#region #usings
using DevExpress.XtraRichEdit.Utils;
using DevExpress.Office.Utils;
using DevExpress.Office.Services;
#endregion #usings

namespace Retain_Img_Src {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void richEditControl1_Loaded(object sender, RoutedEventArgs e) {
            ApplyTemplate();
            richEditControl1.LoadDocument("test.htm");
            richEditControl1.ContentChanged += new EventHandler(richEditControl1_ContentChanged);
        }
        private void richEditControl1_ContentChanged(object sender, EventArgs e)
        {
            memoEdit1.Text = richEditControl1.Document.GetHtmlText(richEditControl1.Document.Range, new CustomUriProvider());
        }
        #region #documentloaded
        private void richEditControl1_DocumentLoaded(object sender, EventArgs e)
        {
            IUriProviderService service = richEditControl1.GetService<IUriProviderService>();
            if (service != null) {
                service.RegisterProvider(new CustomUriProvider());
            }
        }
        #endregion #documentloaded
    }
    #region #customuriprovider
    public class CustomUriProvider : IUriProvider
    {
        #region IUriProvider Members
        public string CreateCssUri(string rootUri, string styleText, string relativeUri)
        {
            return String.Empty;
        }

        public string CreateImageUri(string rootUri, OfficeImage image, string relativeUri)
        {
            return image.Uri;
        }
        #endregion
    }
    #endregion #customuriprovider
}
