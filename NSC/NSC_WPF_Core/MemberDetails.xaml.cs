﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NSC_Model;
using NSC_Business;

namespace NSC_WPF_Core
{
    /// <summary>
    /// Interaction logic for MemberDetails.xaml
    /// </summary>
    public partial class MemberDetails : Page
    {
        private CRUDMembers _crudMembers = new CRUDMembers();
        private CRUDBookings _crudBookings = new CRUDBookings();

        public MemberDetails()
        {
            InitializeComponent();
            ComboRoom.ItemsSource = _crudBookings.AllRooms_ID();
            ComboSport.ItemsSource = _crudBookings.AllSports_ID();
            ComboTime.ItemsSource = _crudBookings.AllTime();
        }

        public MemberDetails(string username) : this()
        {
            //int chosen_ID = _crudMembers.SelectMember.MemberId;
            FillMemberDetails(username);
            FillBookingList(username);
        }

        private void FillMemberDetails(string username)
        {
            _crudMembers.ChooseMember(username);
            TextUsername.Text = _crudMembers.SelectMember.Username;
            TextID.Text = _crudMembers.SelectMember.MemberId.ToString();
        }

        private void FillBookingList(string username)
        {
            ListBookings.ItemsSource = _crudMembers.MemberBookings(username);
        }

        private void ListBookings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBookings.SelectedItem != null)
            {
                _crudBookings.ChosenBooking(ListBookings.SelectedItem);
                TextBookingID.Text = _crudBookings.SelectBooking.BookingId.ToString();
                ComboRoom.SelectedItem = _crudBookings.SelectBooking.RoomId;
                ComboSport.SelectedItem = _crudBookings.SelectBooking.SportId;
                PickDate.SelectedDate = _crudBookings.SelectBooking.DateNeeded;
                ComboTime.SelectedItem = _crudBookings.SelectBooking.TimeSlot;
            }
        }

        private void ComboRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ButtonNewBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //_crudBookings.UpdateBooking(Convert.ToInt32(TextBookingID.Text), ComboRoom.SelectedItem,ComboSport.SelectedItem, PickDate.SelectedDate.GetValueOrDefault(), ComboTime.SelectedItem.ToString())
        }
    }
}
