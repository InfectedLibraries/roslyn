﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;

namespace Microsoft.CodeAnalysis.MoveToNamespace
{
    internal class MoveToNamespaceOptionsResult
    {
        public static readonly MoveToNamespaceOptionsResult Cancelled = new MoveToNamespaceOptionsResult(isCancelled: true);

        public bool IsCancelled { get; }
        public string Namespace { get; }

        public MoveToNamespaceOptionsResult(bool isCancelled)
        {
            IsCancelled = true;
        }

        public MoveToNamespaceOptionsResult(string @namespace)
        {
            Namespace = @namespace;
        }
    }
}
