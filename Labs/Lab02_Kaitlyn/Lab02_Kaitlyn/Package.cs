using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_Kaitlyn
{
    class Package: IComparable
    {
        //public automatice get set property for the Name of package
        public string Name { get; set; }

        //list of the strings as well as a get to copy them 
        private List<string> _collection;
        public List<string> collection 
            {
                get { return new List<string>(_collection); }
            }


        //constructor accepting of a string array
        public Package(string[] StringArray)
        {
            //first element is always the name 
            Name = StringArray[0];
            //initialize the new collection list 
            _collection = new List<string>();

            //iterate through each string in the array
            for(int i = 1; i<StringArray.Length; i++)
            {
                //if there are not any duplicates then we add it
                //that element to the collection
                if (!_collection.Contains(StringArray[i]))
                    _collection.Add(StringArray[i]);
            }

        }

        //constructor accepting just a string
        //string is initialized as the name and the collection is 
        //set to null
        public Package(string newString)
        {
            Name = newString;
            _collection = null;
        }

        //override equals where packages are equal if the names are the same
        /// override equals to see whther the names of the packages are the same
        /// method accepts an object (which we hopefully turn into a packages)
        /// and return a bool
        public override bool Equals(object obj)
        {
            //make sure the passed object is actually a package
            //if it is cast it to a package
            if (!(obj is Package)) return false;
            Package arg = obj as Package;
            //return true if the names are equal
            return this.Name.Equals(arg.Name);
        }

        //need this to use overrides
        public override int GetHashCode()
        {
            return 1;
        }

        //string override to format the name
        /// ToString override for the dependency names in the listview
        /// method accepts nothing and returns a string
        public override string ToString()
        {
            //make a temp string
            string temp = "";
            //foreach through the collections and format them with a comma in between
            this.collection.ForEach(thing => temp += (thing + ", "));
            //return the string
            return temp;
        }

        //comparison method CompareTo () default comparison
        /// compareTo method the default comaprator
        /// method accepts an object and returns an int
        public int CompareTo(object obj)
        {
            //instead of throwing false like the equals method this will throw
            //an exception method telling the user that something was wrong
            if (!(obj is Package)) throw new ArgumentException("Not Valid Input");
            //if the obj is valid then we need to cast it
            Package Arg = obj as Package;
            //returns which is greater
            return Name.CompareTo(Arg.Name);

        }

        //Compare by count within name
        ///second comaprison method to compare the count within name
        /// <param name="arg1"> first package we will compare to the second</param>
        /// <param name="arg2"> second package that we will compare to the first</param>
        /// <returns> method returns an int </returns>
        static public int CompareCount(Package arg1, Package arg2)
        {
            //if the names are equal we sort and compare by the count of the collection
            if (arg1.Name.Equals(arg2.Name))
            {
                return arg1.collection.Count.CompareTo(arg2.collection.Count);
            }
            //otherwise comapre the same way the CompareTo method does(by name)
            else
                return arg1.Name.CompareTo(arg2.Name);
        }

        //Compare by name within count
        ///third comaprison method to compare the name within count
        /// <param name="arg1"> first package we will compare to the second</param>
        /// <param name="arg2"> second package that we will compare to the first</param>
        /// <returns> method returns an int </returns>
        static public int CompareName(Package arg1, Package arg2)
        {
            //if the names are equal we sort and compare by the count of the collection
            if (arg1.Name.Equals(arg2.Name))
            {
                return arg1.Name.CompareTo(arg2.Name);
                
            }
            //otherwise comapre the same way the CompareTo method does(by name)
            else
                return arg1.collection.Count.CompareTo(arg2.collection.Count);
        }

        //Last method of the merge package method
        /// mergepackages method that will be called in the case of already having the package in the list with different dependency 
        /// then merge the two so they become one item in the listview
        /// method returns nothing but accepts a package
        /// <param name="inPack"> the input package </param>
        public void MergePackage(Package inPack)
        {
            //if the two packages do not have the same name throw acception
            if (!(Name.Equals(inPack.Name))) throw new ArgumentException("Not The same package name");
            //if the names are the same then add to the list (no duplicates)
            _collection = _collection.Union(inPack._collection).ToList();
            
        }
    }
}
