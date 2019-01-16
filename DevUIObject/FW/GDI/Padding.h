#pragma once
namespace GDI
{
	class Padding
	{
	public:
		//
		// Summary:
		//     Gets or sets the padding value for the top edge.
		//
		// Returns:
		//     The padding, in pixels, for the top edge.
		int Top;
		//
		// Summary:
		//     Gets or sets the padding value for the right edge.
		//
		// Returns:
		//     The padding, in pixels, for the right edge.
		int Right;
		//
		// Summary:
		//     Gets or sets the padding value for the left edge.
		//
		// Returns:
		//     The padding, in pixels, for the left edge.
		int Left;
		//
		// Summary:
		//     Gets or sets the padding value for the bottom edge.
		//
		// Returns:
		//     The padding, in pixels, for the bottom edge.
		int Bottom;

		Padding();
		~Padding();

		void SetHorizontal(int value);
		void SetAll(int value);
	};
}
