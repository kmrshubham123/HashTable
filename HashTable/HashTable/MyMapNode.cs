using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class MyMapNode<K,V> //Build a key Value pair HashTable   
    {
        ///Variable
        public readonly int size; //size of Hash atble
        ///Linked list of type key & value.
        public readonly LinkedList<keyValue<K, V>>[] items;
        /// <summary>
        /// Initializes a Constructure with int Size Parameter
        /// </summary>
        /// <param name="size">The size.</param>
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<keyValue<K, V>>[size];
        }
        /// <summary>
        /// Gets and sets the values.
        /// </summary>
        /// <typeparam name="k"></typeparam>
        /// <typeparam name="v"></typeparam>
        public struct keyValue<k, v> //key value is passed into the Above Linked list Key,value
        {
            public k key { get; set; }
            public v value { get; set; }
        }
        /// <summary>
        /// GetLinkedlist is a method and having a return type LinkedList key value pair.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        protected LinkedList<keyValue<K, V>> GetLinkedlist(int position)
        {
            LinkedList<keyValue<K, V>> linkedLlist = items[position];
            if (linkedLlist == null)
            {
                linkedLlist = new LinkedList<keyValue<K, V>>();
                items[position] = linkedLlist;
            }
            return linkedLlist;
        }
        /// <summary>
        /// Gets the array postion.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected int GetArrayPostion(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// Gets the value provided by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V Get(K key) //Generic method define the value V
        {
            int position = GetArrayPostion(key); 
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);
            foreach (keyValue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    return item.value;
                }
            }
            return default;
        }
        /// <summary>
        /// Adds the specified key.
        /// pushing the data into ther Hash table using the linked list operations.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(K key, V value)
        {
            int position = GetArrayPostion(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);

            keyValue<K, V> item = new keyValue<K, V>() { key = key, value = value };
            linkedlist.AddLast(item);
        }
        /// <summary>
        /// UC2:-Ability to find Frequency of word in a large Paragraph phrase
        /// Gives the count the of word provided.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetFrequency(V value)
        {
            int frequency = 0;
            ///Iterating to get the key value of each item.
            foreach (LinkedList<keyValue<K, V>> list in items)
            {
                ///Checking if key is not null 
                if (list == null)
                    continue;
                ///Iterating to get the value of the item in linked list.
                foreach (keyValue<K, V> item in list)
                {
                    if (item.Equals(null))
                        continue;
                    if (item.value.Equals(value))
                        frequency++;
                }
            }
            return frequency;
             
        }
        /// <summary>
        /// Removes the value provided by key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(K key)
        {
            int position = GetArrayPostion(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);

            bool itemFound = false;

            keyValue<K, V> foundItem = default(keyValue<K, V>);
            foreach (keyValue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedlist.Remove(foundItem);
            }
        }
        /// <summary>
        /// Removes the given value.
        /// </summary>
        /// <param name="value"></param>
        public void RemoveValue(V value)
        {
            foreach (LinkedList<keyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (keyValue<K, V> item in list)
                {
                    if (item.Equals(null))
                        continue;
                    if (item.value.Equals(value))
                    {
                        Remove(item.key);
                        break;
                    }
                }
            }
        }
    }
}
