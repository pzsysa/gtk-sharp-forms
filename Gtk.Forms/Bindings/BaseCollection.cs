// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2004-2005 Novell, Inc.
//
// Authors:
//	Peter Bartok	pbartok@novell.com
//

// COMPLETE

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace GtkForms {
	public class BaseCollection : MarshalByRefObject, ICollection, IEnumerable {
		internal ArrayList	list;

		#region Public Constructors
		public BaseCollection ()
		{
		}		 
		#endregion	// Public Constructors

		#region Public Instance Properties
//		[Browsable(false)]
//		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual int Count {
			get {
				return List.Count;
			}
		}

//		[Browsable(false)]
//		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool IsReadOnly {
			get {
				return false;
			}
		}

//		[Browsable(false)]
//		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool IsSynchronized {
			get {
				return false;
			}
		}

//		[Browsable(false)]
//		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public object SyncRoot {
			get {
				return this;
			}
		}
		#endregion	// Public Instance Properties

		#region Protected Instance Properties
		protected virtual ArrayList List {
			get {
				if (list == null)
					list = new ArrayList ();
				return list;
			}
		}
		#endregion	// Protected Instance Properties

		#region Public Instance Methods
		public void CopyTo (Array ar, int index)
		{
			List.CopyTo (ar, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return List.GetEnumerator ();
		}
		#endregion	// Public Instance Methods
	}
	
	public class BaseCollection <T> : IList <T>, ICollection <T>, IEnumerable <T>, IList, ICollection, IEnumerable
	{
		IList <T> list;
		object syncRoot;
		
		public BaseCollection ()
		{
			List <T> l = new List <T> ();
			IList l2 = l as IList;
			syncRoot = l2.SyncRoot;
			list = l;
		}

		public BaseCollection (IList <T> list)
		{
			if (list == null)
				throw new ArgumentNullException ("list");
			this.list = list;
			ICollection l = list as ICollection;
			syncRoot = (l != null) ? l.SyncRoot : new object ();
		}

		public void Add (T item)
		{
			int idx = list.Count;
			InsertItem (idx, item);
		}

		public void Clear ()
		{
			ClearItems ();
		}

		protected virtual void ClearItems ()
		{
			list.Clear ();
		}

		public bool Contains (T item)
		{
			return list.Contains (item);
		}

		public void CopyTo (T [] array, int index)
		{
			list.CopyTo (array, index);
		}

		public IEnumerator <T> GetEnumerator ()
		{
			return list.GetEnumerator ();
		}

		public int IndexOf (T item)
		{
			return list.IndexOf (item);
		}

		public void Insert (int index, T item)
		{
			InsertItem (index, item);
		}

		protected virtual void InsertItem (int index, T item)
		{
			list.Insert (index, item);
		}

		protected IList<T> Items {
			get { return list; }
		}

		public bool Remove (T item)
		{
			int idx = IndexOf (item);
			if (idx == -1) 
				return false;
			
			RemoveItem (idx);
			
			return true;
		}

		public void RemoveAt (int index)
		{
			RemoveItem (index);
		}

		protected virtual void RemoveItem (int index)
		{
			list.RemoveAt (index);
		}

		public int Count {
			get { return list.Count; }
		}

		public T this [int index] {
			get { return GetItem (index); }
			set { SetItem (index, value); }
		}

		bool ICollection<T>.IsReadOnly {
			get { return list.IsReadOnly; }
		}

		protected virtual T GetItem (int index)
		{
			return list[index];
		}
		
		protected virtual void SetItem (int index, T item)
		{
			list[index] = item;
		}

		
#region Helper methods for non-generic interfaces
		
		internal static bool IsValidItem (object item)
		{
			return (item is T || (item == null && ! typeof (T).IsValueType));
		}
		
		internal static T ConvertItem (object item)
		{
			if (IsValidItem (item))
				return (T)item;
			throw new ArgumentException ("item");
		}
		
		internal static void CheckWritable (IList <T> list)
		{
			if (list.IsReadOnly)
				throw new NotSupportedException ();
		}
		
		internal static bool IsSynchronized (IList <T> list)
		{
			ICollection c = list as ICollection;
			return (c != null) ? c.IsSynchronized : false;
		}
		
		internal static bool IsFixedSize (IList <T> list)
		{
			IList l = list as IList;
			return (l != null) ? l.IsFixedSize : false;
		}
#endregion

#region Not generic interface implementations
		void ICollection.CopyTo (Array array, int index)
		{
			((ICollection)list).CopyTo (array, index);
		}
		
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return (IEnumerator) list.GetEnumerator ();
		}
				
		int IList.Add (object value)
		{
			int idx = list.Count;
			InsertItem (idx, ConvertItem (value));
			return idx;
		}
		
		bool IList.Contains (object value)
		{
			if (IsValidItem (value))
				return list.Contains ((T) value);
			return false;
		}
		
		int IList.IndexOf (object value)
		{
			if (IsValidItem (value))
				return list.IndexOf ((T) value);
			return -1;
		}
		
		void IList.Insert (int index, object value)
		{
			InsertItem (index, ConvertItem (value));
		}
		
		void IList.Remove (object value)
		{
			CheckWritable (list);

			int idx = IndexOf (ConvertItem (value));

			RemoveItem (idx);
		}
		
		bool ICollection.IsSynchronized {
			get { return IsSynchronized (list); }
		}
		
		object ICollection.SyncRoot {
			get { return syncRoot; }
		}
		bool IList.IsFixedSize {
			get { return IsFixedSize (list); }
		}
		
		bool IList.IsReadOnly {
			get { return list.IsReadOnly; }
		}
		
		object IList.this [int index] {
			get { return GetItem (index); }
			set { SetItem (index, ConvertItem (value)); }
		}
#endregion
	}
}
