/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The Original Code is www.com code.
 *
 * The Initial Developer of the Original Code is
 * Lagash Systems SA.
 * Portions created by the Initial Developer are Copyright (C) 2004
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *   Diego Gonzalez <diegog@com>
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either of the GNU General Public License Version 2 or later (the "GPL"),
 * or the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 *
 * ***** END LICENSE BLOCK ***** */

using System;
using cor = Xacml.Core;

namespace Xacml.Core.Policy
{
    /// <summary>
    /// Defines a typed collection of read-only TargetItems.
    /// </summary>
    public class TargetItemCollection : TargetItemReadWriteCollection
    {
        #region Constructor

        /// <summary>
        /// Creates a TargetItemCollection, with the items contained in a ReadWriteTargetItemCollection
        /// </summary>
        /// <param name="items"></param>
        public TargetItemCollection(TargetItemReadWriteCollection items)
        {
            if (items == null) throw new ArgumentNullException("items");
            foreach (TargetItemBaseReadWrite item in items)
            {
                SubjectElementReadWrite sItem = item as SubjectElementReadWrite;
                ActionElementReadWrite aItem = item as ActionElementReadWrite;
                ResourceElementReadWrite rItem = item as ResourceElementReadWrite;
                EnvironmentElementReadWrite eItem = item as EnvironmentElementReadWrite;
                if (sItem != null)
                {
                    this.List.Add(new SubjectElement(sItem.Match, sItem.SchemaVersion));
                }
                else if (aItem != null)
                {
                    this.List.Add(new ActionElement(aItem.Match, aItem.SchemaVersion));
                }
                else if (rItem != null)
                {
                    this.List.Add(new ResourceElement(rItem.Match, rItem.SchemaVersion));
                }
                else if (eItem != null)
                {
                    this.List.Add(new EnvironmentElement(eItem.Match, eItem.SchemaVersion));
                }
            }
        }

        /// <summary>
        /// Creates a new blank TargetItemCollection
        /// </summary>
        public TargetItemCollection()
        {
        }

        #endregion

        #region CollectionBase members

        /// <summary>
        /// Clears the collection
        /// </summary>
        public override void Clear()
        {
            throw new NotSupportedException();
        }
        /*
                /// <summary>
                /// Adds an object to the end of the CollectionBase.
                /// </summary>
                /// <param name="value">The Object to be added to the end of the CollectionBase. </param>
                /// <returns>The CollectionBase index at which the value has been added.</returns>
                public override int Add( TargetItemBase value )  
                {
                    throw new NotSupportedException();
                }
        */
        /// <summary>
        /// Removes the specified element
        /// </summary>
        /// <param name="index">Position of the element</param>
        public override void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
