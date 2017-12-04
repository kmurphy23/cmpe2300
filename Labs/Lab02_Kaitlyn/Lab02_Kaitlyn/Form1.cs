using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab02_Kaitlyn
{
    public partial class Form1 : Form
    {
        //enumeration to give the index of the choice for the sorting
        private enum SortType { RawList, LibraryList, SortedList }
        //Three list for the collecitons
        List<Package> Loaded = new List<Package>();   //whatever is loadable
        List<Package> UnInstallable = new List<Package>(); //whatever is uninstallable
        List<Package> Installable = new List<Package>(); //what is installable
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //sets the initial indexes to the first choice of each comobo box
            comboBox1.SelectedIndex = 0; //the sort type
            comboBox2.SelectedIndex = 0; //and the type of packages
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {

            //if the fileLoad is ok then we continue
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //clear all of the list so we can start from scatch
                Loaded.Clear();
                Installable.Clear();
                UnInstallable.Clear();
                //create temporary arrays and packages to hold new info we will pass it 
                string[] output;
                Package tempPack;

                //go through each line of the selected file
                foreach (string line in System.IO.File.ReadAllLines(openFileDialog1.FileName))
                {
                    //put each new line split it and put it into the output string array
                    output = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //fill the temp package with the input from the strings
                    tempPack = new Package(output);
                    //if we cant find the package in the loaded list
                    if (!Loaded.Contains(tempPack))
                        //we add it to the list
                        Loaded.Add(tempPack);
                    else
                        //if it is here then we find the index of it and merge the two packages together 
                        Loaded[Loaded.IndexOf(tempPack)].MergePackage(tempPack);
                }
                //reset the index of the installable
                comboBox2.SelectedIndex = 0;
                //call the show method 
                ShowSelectedLoad();

            }

        }

        /// name:ShowSelectedLoad
        /// method accepts nothing and returns nothing 
        /// this method is called whenever there is a change (analyze btn load btn etc..)
        /// picks which way we will sort it and what we are looking to sort (whether that be loaded, installable, or uninstallable)
        private void ShowSelectedLoad()
        {
            //clear the list view 
            listView1.Items.Clear();
            //find what the index is from the combo box 
            int sortBy = comboBox2.SelectedIndex;
            //also delcare a dummy package just to dump stuff in 
            List<Package> reference;
            //switch statment to find what the list type will 
            switch (sortBy)
            {
                //first index is loaded
                case 0:
                    reference = Loaded;
                    break;
                //second is installable
                case 1:
                    reference = Installable;
                    break;
                //third is uninstallable
                case 2:
                    reference = UnInstallable;
                    break;
                //default is nothing
                default:
                    reference = null;
                    break;

            }
            //filter through each package in the reference list(which we found from above switch statement)
            foreach (Package P in reference)
            {
                //add a new listview item with the name and dependency name to the listview 
                ListViewItem temp = new ListViewItem(new[] { P.Name, P.ToString(), });
                listView1.Items.Add(temp);
            }
            //updates the progress bars on the bottom of the screen to see each loaded installable or uninstallable
            PackLoadBar.Text = $"{Loaded.Count} Packs Loaded";
            PackInstBar.Text = $"{Installable.Count} Packs Installable";
            UninstBar.Text = $"{UnInstallable.Count} Packs Unistallable";

        }

        private void AnalyzeBtn_Click(object sender, EventArgs e)
        {
            //if we actually have something in the list 
            //then we initialize the stuff for uninstallable or installable
            if (Loaded.Count > 0)
            {
                UnInstallable = new List<Package>(Loaded);
                Installable = new List<Package>();
            }
            //start the stopwatch
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //pick the sort type 
            SortType sort = (SortType)comboBox1.SelectedIndex;
            //reset it so its zero when we start 
            stopwatch.Restart();
            //switch statment to see what sorting type weve chossen 
            switch (sort)
            {
                //depending on the sort type we call the corresponding method 
                case SortType.RawList:
                    Raw();
                    break;
                case SortType.LibraryList:
                    Library();
                    break;
                case SortType.SortedList:
                    SortInstall();
                    break;
            }
            //stop the stop watch
            stopwatch.Stop();
            //send the timer amount to the form1 text
            Text = stopwatch.Elapsed.TotalSeconds.ToString("F4");
            //default the selected index of the packages loaded and 
            comboBox2.SelectedIndex = 1;
            //call show method
            ShowSelectedLoad();
        }


        /// raw sorting list 
        /// this method accepts nothing and returns nothing 
        private void Raw()
        {
            //Loop to go through the code in a do while initialized to false
            bool installLoop = false;
            //loop continously through until installLoop is turned to false
            do
            {
                //make sure its false
                installLoop = false;
                //go through each package in uninstallable 
                foreach (Package p in UnInstallable)
                {
                    //if the package dependency count is nothing
                    if (p.collection.Count == 0)
                    {
                        //add package to the installable list
                        Installable.Add(p);
                        //turn the loop true again 
                        installLoop = true;
                        //remove the installed package from uninstallable
                        UnInstallable.Remove(p);
                        //break out
                        break;
                    }
                    //boolean to check if all the dependencies have been filtered through
                    bool allDepend = false;
                    //for every uninstalled package, look through all the dependant packages
                    foreach (string s in p.collection)
                    {
                        //make sure the initialized bool is false
                        allDepend = false;
                        //go through each package in the installable list 
                        foreach (Package pa in Installable)
                        {
                            //if the string name in the package is not there
                            if (s != pa.Name)
                            {
                                //turn the dependencies to false
                                allDepend = false;
                            }
                            else
                            {
                                //otherwise turn the bool to true
                                allDepend = true;
                                break;
                            }
                        }
                        //if the bool is true we just break out
                        if (!allDepend)
                        {
                            break;
                        }
                    }
                    //if the bool is true
                    if (allDepend)
                    {
                        //add the package to the installable list
                        Installable.Add(p);
                        //turn the list true
                        installLoop = true;
                        //remove it from the uninstallable list
                        UnInstallable.Remove(p);
                        break;
                    }
                }
                //loop until false
            } while (installLoop);
        }


        /// this is to sort using a library helper method
        /// method returns nothing and accepts nothing
        private void Library()
        {
            //install is false (similar process to the last method)
            bool install = false;
            do
            {
                //turn install to false
                install = false;
                //go through each package in the uninstallable list
                foreach (Package uninstalled in UnInstallable)
                {
                    //if the uninstallable dependicency is zero 
                    if (uninstalled.collection.Count == 0)
                    {
                        //add it to installable list 
                        Installable.Add(uninstalled);
                        //turn variable true
                        install = true;
                        //remove the pakcage from the uninstallable
                        UnInstallable.Remove(uninstalled);
                        break;
                    }
                    //go through the list find the true for all dependencies and find if anything in the list contains the package
                    else if (uninstalled.collection.TrueForAll(depend => Installable.Contains(new Package(new[] { depend }))))
                    {
                        //add the uninstallable package to the installable package
                        Installable.Add(uninstalled);
                        //turn bool to true
                        install = true;
                        //remove packages from uninstallable list
                        UnInstallable.Remove(uninstalled);
                        break;
                    }
                }
            } while (install);

        }


        /// sort method 
        /// method returns nothing and accepts nothing
        /// This methid is called based on what the user wants to sort the ist by
        private void SortInstall()
        {
            //boolean to iterate through the do while
            bool install = false;
            do
            {
                //make sure the bol install is still false
                install = false;
                //sort the installable list
                Installable.Sort();
                //iterate though each uninstallable package in uninstallable
                foreach (Package uninstalled in UnInstallable)
                {
                    //count the dependencies if its zero then we ...
                    if (uninstalled.collection.Count == 0)
                    {
                        //add the uninstalled package to the installable package
                        Installable.Add(uninstalled);
                        //change the ool to true so we keep iterating
                        install = true;
                        //remove the previouly installed package from the uninstallable list
                        UnInstallable.Remove(uninstalled);
                        break;
                    }
                    //otherwise if the dependency count is not zero we use a binary search to help sort the list
                    else if (uninstalled.collection.TrueForAll(depend => Installable.BinarySearch(new Package(new[] { depend })) >= 0))
                    {
                        //add the previousy removed package into the installable list
                        Installable.Add(uninstalled);
                        //turn boolean true
                        install = true;
                        //remove the package from the uninstalled list
                        UnInstallable.Remove(uninstalled);

                        break;

                    }
                }
            } while (install);

        }

        //any time the combo box is changed the display method is called
        /// this is called whenever the combo box changes 
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedLoad();
        }


        //whenever the listview item is clicked(either the package or dependency column) we jump into here
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //based on what what the choice is we will call either the sort by...
            if (e.Column == 0)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    //name within count then we load and show the list in the listview
                    Loaded.Sort(Package.CompareCount);
                    ShowSelectedLoad();
                }
                //again sort by name within count 
                if (comboBox2.SelectedIndex == 1)
                {
                    //but this time is the installable list
                    Installable.Sort(Package.CompareCount);
                    ShowSelectedLoad();
                }
                else
                {
                    //then we sort the uninstallable list by the same order 
                    UnInstallable.Sort(Package.CompareCount);
                    ShowSelectedLoad();
                }
            }
            //if the user selects to sort the columns by name it will jump into here
            else if (e.Column == 1)
            {
                //here we sort the loaded packages then load and display the itms to the listview
                if (comboBox2.SelectedIndex == 0)
                {
                    Loaded.Sort(Package.CompareName);
                    ShowSelectedLoad();
                }
                //next choice is if the user wants to order by installable packages
                else if (comboBox2.SelectedIndex == 1)
                {
                    Installable.Sort(Package.CompareName);
                    ShowSelectedLoad();
                }
                //and finally the last choice is to order by the uninstallable packages
                else
                {
                    UnInstallable.Sort(Package.CompareName);
                    ShowSelectedLoad();
                }
            }
        }
    }
}
