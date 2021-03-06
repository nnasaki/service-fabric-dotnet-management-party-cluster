﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Domain
{
    using System.Threading.Tasks;

    public interface ICaptcha
    {
        Task<bool> VerifyAsync(string captchaResponse);
    }
}