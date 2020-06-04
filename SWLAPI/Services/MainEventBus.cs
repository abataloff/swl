using System;
using System.Net.Mail;
// ReSharper disable UseNullPropagation

namespace SWLAPI.Services
{
    public class MainEventBus
    {        
        public event EventHandler<AuthByEmailLinkEventArgs> AuthenticationByEmailLinkRequested;
        public event EventHandler<InviteByEmailEventArgs> InviteUserByEmailRequested;

        public void DoAuthByEmailLinkRequested(object sender, AuthByEmailLinkEventArgs eventArgs)
        {
            if (AuthenticationByEmailLinkRequested != null)
                AuthenticationByEmailLinkRequested.Invoke(sender, eventArgs);
        }

        public void DoAuthByEmailLinkRequested(object sender, MailAddress mailAddress)
        {
            DoAuthByEmailLinkRequested(sender, new AuthByEmailLinkEventArgs(mailAddress));    
        }

        public void DoInviteUserByEmailRequested(object sender, InviteByEmailEventArgs eventArgs)
        {
            if (InviteUserByEmailRequested != null)
                InviteUserByEmailRequested.Invoke(sender, eventArgs);
        }

        public void DoInviteUserByEmailRequested(object sender, MailAddress mailAddress)
        {
            DoInviteUserByEmailRequested(sender, new InviteByEmailEventArgs(mailAddress));
        }
    }

    public class AuthByEmailLinkEventArgs : EventArgs
    {
        public MailAddress Email { get; }

        public AuthByEmailLinkEventArgs(MailAddress email)
        {
            Email = email;
        }
    }
    public class InviteByEmailEventArgs : EventArgs
    {
        public MailAddress Email { get; }

        public InviteByEmailEventArgs(MailAddress email)
        {
            Email = email;
        }
    }
}