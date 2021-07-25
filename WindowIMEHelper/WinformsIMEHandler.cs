using System;
using System.Drawing;

namespace IMEHelper
{
    /// <summary>
    /// Integrate IME to XNA framework.
    /// </summary>
    public class WinFormsIMEHandler : IMEHandler, IDisposable
    {
        private IMENativeWindow _nativeWnd;

        public WinFormsIMEHandler(IntPtr handle, bool showDefaultIMEWindow = false) : base(handle, showDefaultIMEWindow)
        {
        }

        public override void PlatformInitialize()
        {
            _nativeWnd = new IMENativeWindow(this, Handle, ShowDefaultIMEWindow);
        }

        public override bool Enabled { get; protected set; }

        public override void StartTextComposition()
        {
            if (Enabled)
                return;

            Enabled = true;
            _nativeWnd.EnableIME();
        }

        public override void StopTextComposition()
        {
            if (!Enabled)
                return;

            Enabled = false;
            _nativeWnd.DisableIME();
        }

        public override void SetTextInputRect(ref Rectangle rect)
        {
            if (!Enabled)
                return;

            _nativeWnd.SetTextInputRect(ref rect);
        }

        public override string[] Candidates { get { return _nativeWnd.Candidates; } }
        public override uint CandidatesPageSize { get { return _nativeWnd.CandidatesPageSize; } }
        public override uint CandidatesPageStart { get { return _nativeWnd.CandidatesPageStart; } }
        public override uint CandidatesSelection { get { return _nativeWnd.CandidatesSelection; } }

        public override string Composition { get { return _nativeWnd.CompositionString; } }
        public override string CompositionClause { get { return _nativeWnd.CompositionClause; } }
        public override string CompositionRead { get { return _nativeWnd.CompositionReadString; } }
        public override string CompositionReadClause { get { return _nativeWnd.CompositionReadClause; } }
        public override int CompositionCursorPos { get { return _nativeWnd.CompositionCursorPos; } }

        public override string Result { get { return _nativeWnd.ResultString; } }
        public override string ResultClause { get { return _nativeWnd.ResultClause; } }
        public override string ResultRead { get { return _nativeWnd.ResultReadString; } }
        public override string ResultReadClause { get { return _nativeWnd.ResultReadClause; } }

        public override CompositionAttributes GetCompositionAttr(int charIndex)
        {
            return _nativeWnd.GetCompositionAttr(charIndex);
        }

        public override CompositionAttributes GetCompositionReadAttr(int charIndex)
        {
            return _nativeWnd.GetCompositionReadAttr(charIndex);
        }

        /// <summary>
        /// Dispose everything
        /// </summary>
        public void Dispose()
        {
            _nativeWnd.Dispose();
        }
    }
}
