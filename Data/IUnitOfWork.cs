﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void AsyncSave();
    }
}
