﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LayUI.Avalonia.Interface
{
    public interface ILayDialogAware
    {
        event Action<ILayDialogResult> RequestClose;
        void OnDialogOpened(ILayDialogParameter parameters);
    }
}
