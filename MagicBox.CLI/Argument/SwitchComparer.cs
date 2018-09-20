using System.Collections.Generic;
using System.Globalization;

namespace MagicBox.CLI.Argument
{
	/// <summary>
	/// Compares Switch objects.
	/// </summary>
	class SwitchComparer : IComparer<Switch>
	{
		/// <summary>
		/// Compare given Switch objects by name.
		/// </summary>
		/// <param name="x">
		/// Switch object representing first switch to compare by name.
		/// </param>
		/// <param name="y">
		/// Switch object representing second switch to compare by name.
		/// </param>
		/// <returns>
		/// Integer representing the sort order of given switches.
		/// </returns>
		public int Compare(Switch x, Switch y)
		{
			return string.Compare(x.Name, y.Name, true,
				CultureInfo.CurrentCulture);
		}
	}
}
