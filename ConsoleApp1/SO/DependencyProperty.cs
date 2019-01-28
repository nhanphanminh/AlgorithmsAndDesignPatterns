using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Animation;

namespace ConsoleApp1.SO
{
    public abstract class Base : Animatable
    {
        public static readonly DependencyProperty TriggerProperty;
        protected static List<DependencyProperty> IgnoreOnChanged { get; }
        static Base() =>
            TriggerProperty = DependencyProperty.Register(
                "Trigger", typeof(object), typeof(Parent));
        public object Trigger
        {
            get => this.GetValue(TriggerProperty);
            set => this.SetValue(TriggerProperty, value);
        }
    }

    public class Parent : Base
    {
        public static readonly DependencyProperty ChildProperty;

        static Parent()
        {
            ChildProperty = DependencyProperty.Register(
                "Child", typeof(Child), typeof(Parent),
                new PropertyMetadata(null as Child, _OnChildChanged));

            void _OnChildChanged(
                DependencyObject sender,
                DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue == e.OldValue)
                {

                }

                Console.WriteLine("Child Changed!");
            }
        }

        public Parent() : base() =>
            this.Child = new Child();


        public Child Child
        {
            get => this.GetValue(ChildProperty) as Child;
            set => this.SetValue(ChildProperty, value);
        }

        protected override Freezable CreateInstanceCore() => new Parent();
    }

    public class Child : Base
    {
        public Child() : base() { }
        protected override Freezable CreateInstanceCore() => new Child();
    }
}
