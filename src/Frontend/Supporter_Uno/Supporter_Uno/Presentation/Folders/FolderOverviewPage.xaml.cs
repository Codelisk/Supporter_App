using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ReactiveUI;
using ReactiveUI.Uno;
using Supporter_Uno.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Supporter_Uno.Presentation.Folders;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public partial class FolderOverviewPage
{
    public FolderOverviewPage()
    {
        this.InitializeComponent();
        //this.WhenActivated(disposables =>
        //{
        //    var xyz = this.DataContext;
        //    Console.WriteLine("");
        //});
    }
}
