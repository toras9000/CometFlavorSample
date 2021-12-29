using System;
using CometFlavor.Collections;
using Prism.Mvvm;

namespace CometFlavorSample.ViewModels
{
    /// <summary>
    /// アプリケーション共通のベースViewModel
    /// </summary>
    public class AppViewModel : BindableBase, IDisposable
    {
        // 構築
        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public AppViewModel()
        {
            this.Disposables = new CombinedDisposables();
        }
        #endregion

        // 公開メソッド
        #region 破棄
        /// <summary>
        /// リソース破棄
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        // 保護プロパティ
        #region リソース管理
        /// <summary>リソース管理コレクション</summary>
        protected CombinedDisposables Disposables { get; }
        #endregion

        // 保護メソッド
        #region 破棄
        /// <summary>
        /// リソースを破棄する
        /// </summary>
        /// <param name="disposing">マネージド リソース破棄過程であるか</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // マネージド リソース破棄
                    this.Disposables.Dispose();
                }

                // アンマネージド リソース破棄
                disposed = true;
            }
        }
        #endregion

        // 保護プロパティ
        #region 状態管理
        /// <summary>破棄済みフラグ</summary>
        private bool disposed;
        #endregion
    }
}
