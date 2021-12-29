using System.IO;
using System.Linq;
using System.Reactive.Linq;
using CometFlavor.Extensions.IO;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace CometFlavorSample.ViewModels
{
    public class OthersPanelViewModel : AppViewModel
    {
        public OthersPanelViewModel()
        {
            this.DropBaseTargetCommand = new ReactiveCommand<string[]>()
                .AddTo(this.Disposables);

            this.DropRelativeTargetCommand = new ReactiveCommand<string[]>()
                .AddTo(this.Disposables);

            this.BaseTargetDirectory = this.DropBaseTargetCommand
                .Select(paths => paths?.FirstOrDefault())
                .Select(path => File.Exists(path) ? new FileInfo(path).Directory
                              : Directory.Exists(path) ? new DirectoryInfo(path)
                              : null)
                .ToReadOnlyReactivePropertySlim();

            this.BaseTarget = this.BaseTargetDirectory
                .Select(dir => dir?.FullName)
                .ToReadOnlyReactivePropertySlim();

            this.RelativeTarget = this.DropRelativeTargetCommand
                .Select(paths => paths?.FirstOrDefault())
                .Select(path => this.BaseTargetDirectory.Value == null ? null
                              : File.Exists(path) ? new FileInfo(path).RelativePathFrom(this.BaseTargetDirectory.Value, ignoreCase: true)
                              : Directory.Exists(path) ? new DirectoryInfo(path).RelativePathFrom(this.BaseTargetDirectory.Value, ignoreCase: true)
                              : null)
                .ToReadOnlyReactivePropertySlim();
        }

        public ReactiveCommand<string[]> DropBaseTargetCommand { get; }
        public ReactiveCommand<string[]> DropRelativeTargetCommand { get; }

        public ReadOnlyReactivePropertySlim<DirectoryInfo?> BaseTargetDirectory { get; }

        public ReadOnlyReactivePropertySlim<string?> BaseTarget { get; }
        public ReadOnlyReactivePropertySlim<string?> RelativeTarget { get; }
    }
}
