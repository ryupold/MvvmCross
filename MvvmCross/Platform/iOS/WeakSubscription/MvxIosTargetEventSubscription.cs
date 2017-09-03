using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MvvmCross.Platform.WeakSubscription;
using System.Reflection;
using ObjCRuntime;

namespace MvvmCross.Platform.iOS.WeakSubscription
{
    public class MvxIosTargetEventSubscription<TSource, TEventArgs> : MvxWeakEventSubscription<TSource, TEventArgs>
    where TSource : class
    {
        public MvxIosTargetEventSubscription(TSource source, string sourceEventName, EventHandler<TEventArgs> targetEventHandler) : base(source, sourceEventName, targetEventHandler)
        {
        }

        protected MvxIosTargetEventSubscription(TSource source, EventInfo sourceEventInfo, EventHandler<TEventArgs> targetEventHandler) : base(source, sourceEventInfo, targetEventHandler)
        {
        }

        protected override object GetTargetObject()
        {
            // If the object has been released but NOT GCed by mono
            // then it is invalid and should not be manipulated.
            var target = base.GetTargetObject();
            var objcObj = target as INativeObject;
            if (objcObj != null && objcObj.Handle == IntPtr.Zero)
            {
                return null;
            }
            return target;
        }

        protected override Delegate CreateEventHandler()
        {
            return new EventHandler<TEventArgs>(OnSourceEvent);
        }
    }
}