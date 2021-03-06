﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace CaveLib.Model.Collection
{
    public class EcObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public EcObservableCollection() : base()
        {
            this.CollectionChanged += 
                new NotifyCollectionChangedEventHandler(EcObservableCollection_CollectionChanged);      
        }

        void EcObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add) {
                foreach (T item in e.NewItems)
                    item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
            }
        }
        public EcObservableCollection(List<T> items) : this()
        {
            foreach (T item in items) {
                this.Add(item);
            }
        }

        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EcObservableCollectionItemChangedEventArgs<T> args = 
                new EcObservableCollectionItemChangedEventArgs<T>();
            args.Item = (T)sender;
            ItemChanged(this, args);
        }

        public event EcObservableCollectionItemChangedEventHandler ItemChanged;

        public delegate void EcObservableCollectionItemChangedEventHandler(object sender, 
                                                            EcObservableCollectionItemChangedEventArgs<T> args);
    }

    public class EcObservableCollectionItemChangedEventArgs<T> : EventArgs
    {
        public T Item { get; set; }
    }    
}
