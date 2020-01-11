using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HDATA_PHARMACY.Security
{
    class UserAccessAttachedProperty
    {
        public static UserType GetUserAccessType(DependencyObject obj)
        {
            return (UserType)obj.GetValue(UserAccessProperty);
        }

        public static void SetUserAccessType(DependencyObject obj, UserType value)
        {
            obj.SetValue(UserAccessProperty, value);
        }


        public static readonly DependencyProperty UserAccessProperty =
                DependencyProperty.RegisterAttached("UserAccessProperty", typeof(UserType), typeof(UserAccessAttachedProperty), new PropertyMetadata(UserType.Simples, new PropertyChangedCallback(UserAcccessConfigure)));

        private static void UserAcccessConfigure(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement userAccess = (FrameworkElement)d;
            if (((UserType)e.NewValue & AppCommon.LogedUserType) == AppCommon.LogedUserType)
                userAccess.Visibility = Visibility.Visible;
            else
                userAccess.Visibility = Visibility.Collapsed;
        }
    }
}
