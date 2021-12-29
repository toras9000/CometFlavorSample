using System.Collections.Generic;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace CometFlavorSample.ViewModels
{
    public class ConvertersPanelViewModel : AppViewModel
    {
        public ConvertersPanelViewModel()
        {
            this.BooleanToVisibilitySource = new ReactivePropertySlim<bool>()
                .AddTo(this.Disposables);

            this.InvertBooleanSource = new ReactivePropertySlim<bool>()
                .AddTo(this.Disposables);

            this.ObjectReferenceSource = new[]
            {
                "Item1",
                "Item2",
                "Item3",
            };

            this.ObjectReferenceSelected = new ReactivePropertySlim<string>()
                .AddTo(this.Disposables);

            this.BooleanCombineSource1 = new ReactivePropertySlim<bool>()
                .AddTo(this.Disposables);

            this.BooleanCombineSource2 = new ReactivePropertySlim<bool>()
                .AddTo(this.Disposables);

            this.BooleanCombineSource3 = new ReactivePropertySlim<bool>()
                .AddTo(this.Disposables);

            this.BooleanCombineSource4 = new ReactivePropertySlim<bool>()
                .AddTo(this.Disposables);
        }

        public ReactivePropertySlim<bool> BooleanToVisibilitySource { get; }
        public ReactivePropertySlim<bool> InvertBooleanSource { get; }
        public IReadOnlyList<string> ObjectReferenceSource { get; }
        public ReactivePropertySlim<string> ObjectReferenceSelected { get; }
        public ReactivePropertySlim<bool> BooleanCombineSource1 { get; }
        public ReactivePropertySlim<bool> BooleanCombineSource2 { get; }
        public ReactivePropertySlim<bool> BooleanCombineSource3 { get; }
        public ReactivePropertySlim<bool> BooleanCombineSource4 { get; }
    }
}
