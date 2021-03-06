﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CaveLib.Controller;
using CaveLib.Model.Collection;
using CaveLib.Model;
using CaveLib.Bean;
using CaveProject.View;
using CaveProject.CustomItem;
using System.Collections.Specialized;

namespace CaveProject.View
{
    /// <summary>
    /// Interaction logic for BouteilleUserControl.xaml
    /// </summary>
    public partial class BouteilleUserControl : UserControl
    {
        private MainController mainController;

        private EcObservableCollection<BouteilleView> bouteilles;

        private Context context;

        public BouteilleUserControl()
        {
            InitializeComponent();

            mainController = MainController.CurrentDao;
            context = Context.CurrentContext;

            this.InitHibernate();
        }

        public void InitHibernate()
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                var criteria = session.CreateCriteria<Bouteille>();
                bouteilles = new EcObservableCollection<BouteilleView>();
                foreach (Bouteille c in criteria.List<Bouteille>())
                    bouteilles.Add(new BouteilleView(c));
            }

            bouteilles.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(bouteilles_CollectionChanged);
            bouteilles.ItemChanged +=
                new EcObservableCollection<BouteilleView>.EcObservableCollectionItemChangedEventHandler(bouteilles_ItemChanged);
            dataGrid1.ItemsSource = bouteilles;
        }

        public void bouteilles_ItemChanged(object sender, EcObservableCollectionItemChangedEventArgs<BouteilleView> args)
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                session.SaveOrUpdate(args.Item.InnerBouteille);
                session.Flush();
            }
        }

        public void bouteilles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            using (var session = mainController.sessionsController.OpenSession())
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (BouteilleView c in e.OldItems)
                        {
                            session.Delete(c.InnerBouteille);
                            session.Flush();
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (BouteilleView c in e.NewItems)
                            session.Save(c.InnerBouteille);
                        break;
                    default:
                        foreach (BouteilleView c in e.OldItems)
                            session.SaveOrUpdate(c.InnerBouteille);
                        break;
                }
            }

        }
    }
}
