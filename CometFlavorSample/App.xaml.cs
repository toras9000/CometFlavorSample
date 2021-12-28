using System.Windows;
using CometFlavorSample.Views;
using Prism.Ioc;

namespace CometFlavorSample;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    /// <summary>
    /// 型の登録
    /// </summary>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    /// <summary>
    /// シェルオブジェクトの生成
    /// </summary>
    protected override Window CreateShell()
    {
        return this.Container.Resolve<MainWindow>();
    }
}
