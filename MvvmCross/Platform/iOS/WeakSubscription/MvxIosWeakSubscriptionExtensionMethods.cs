using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCross.Platform.iOS.WeakSubscription
{
    public static class MvxIosWeakSubscriptionExtensionMethods
    {
        public static MvxIosTargetEventSubscription<TSource, TEventArgs> WeakSubscribe<TSource, TEventArgs>(this TSource source, string eventName, EventHandler<TEventArgs> eventHandler)
            where TSource : class
        {
            return new MvxIosTargetEventSubscription<TSource, TEventArgs>(source, eventName, eventHandler);
        }
    }
}
