using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Helper
{
    public class ApplicationConstant
    {
        public enum ApplicationTypes
        {
            JavaScript = 0,
            NativeConfidential = 1
        };

        public enum EmailType
        {
            VerifyEmail = 0,
            ForgotPassword = 1,
            ResetPassword = 2,
            ContactUs = 3,
            Otp = 4,
            Registration = 5,
            Comment = 6,
            isParticipate = 7,
            ImageSubmission = 8
        }

        public const bool IsStatus_false = false;
        public const bool IsStatus_true = true;
    }
}