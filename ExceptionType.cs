﻿using System;
namespace Accounts
{
    public enum ExceptionType
    {
        ACCOUNT_DOES_NOT_EXIST,
        CREDIT_LIMIT_HAS_BEEN_EXCEEDED,
        NAME_NOT_ASSOCIATED_WITH_ACCOUNT,
        NO_OVERDRAFT,
        PASSWORD_INCORRECT,
        USER_DOES_NOT_EXIST,
        USER_NOT_LOGGED_IN
    }
}

