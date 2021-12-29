using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace CometFlavorSample.ViewModels
{
    public class InteractionsPanelViewModel : AppViewModel
    {
        public InteractionsPanelViewModel()
        {
            this.FileDropCommand = new ReactiveCommand<string[]>()
                .AddTo(this.Disposables);

            this.UrlDropCommand = new ReactiveCommand<string>()
                .AddTo(this.Disposables);

            this.FileDropResult = this.FileDropCommand
                .Select(paths => paths == null ? "<nothing>" : string.Join("\r\n", paths))
                .ToReadOnlyReactivePropertySlim();

            this.UrlDropResult = this.UrlDropCommand
                .Select(url => url ?? "<nothing>")
                .ToReadOnlyReactivePropertySlim();

            this.InputNumber = new ReactivePropertySlim<int>()
                .AddTo(this.Disposables);

            this.InputError = new ReactivePropertySlim<bool>()
                .AddTo(this.Disposables);

            this.TriggerSource = new ReactivePropertySlim<object>()
                .AddTo(this.Disposables);
        }

        public ReactiveCommand<string[]> FileDropCommand { get; }
        public ReactiveCommand<string> UrlDropCommand { get; }

        public ReadOnlyReactivePropertySlim<string?> FileDropResult { get; }
        public ReadOnlyReactivePropertySlim<string?> UrlDropResult { get; }

        public ReactivePropertySlim<int> InputNumber { get; }
        public ReactivePropertySlim<bool> InputError { get; }

        public ReactivePropertySlim<object> TriggerSource { get; }
    }
}
