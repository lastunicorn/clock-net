function ManagedImages(images, smallWidth, smallHeight)
{
	var managedImages;
	var state;
	var smallW;
	var smallH;
	var me = this;

	function getIndexOf(img)
	{
		for (var i = 0; i < managedImages.length; i++)
		{
			if (managedImages[i].src == img.src)
				return i;
		}
		
		return -1;
	}
	
	function toggleImage(img)
	{
		var index = getIndexOf(img);
		
		if (index < 0)
			return;
		
		if (state[index] == 0)
		{
			expandImage(img);
			state[index] = 1;
		}
		else
		{
			shrinkImage(img);
			state[index] = 0;
		}
	}
	
	function onImageClick(e)
	{
		var targ;
		if (!e) var e = window.event;
		if (e.target) targ = e.target;
		else if (e.srcElement) targ = e.srcElement;
		if (targ.nodeType == 3) // defeat Safari bug
			targ = targ.parentNode;

		toggleImage(targ);
	}
	
	this.shrinkAllImages = function()
	{
		for (var i = 0; i < managedImages.length; i++)
		{
			shrinkImage(managedImages[i]);
			state[i] = 0; // shrinked
		}
	}
	
	function shrinkImage(img)
	{
		var smallSize = scaleSize(smallW, smallH, img.width, img.height);
		
		img.style.width = smallSize[0] + "px";
		img.style.height = smallSize[1] + "px";
	}
	
	function expandImage(img)
	{
		var size = getOriginalImageSize(img);
		img.style.width = size[0] + "px";
		img.style.height = size[1] + "px";
	}
	
	function getOriginalImageSize(img)
	{
		var t = new Image();
		t.src = (img.getAttribute ? img.getAttribute("src") : false) || img.src;
		return [t.width, t.height];
	}
	
	function scaleSize(maxW, maxH, currW, currH)
	{
		var ratio = currH / currW;
		
		// ratio < 1 - landscape
		// ratio = 1 - square
		// ratio > 1 - portrait
		
		var newH = currH;
		var newW = currW;
		
		if (ratio <= 1)
		{
			// >> landscape
			
			if (currW > maxW)
			{
				newW = maxW;
				newH = newW * ratio;
			}
		}
		else (ratio >= 1)
		{
			// >> portrait
			
			if (currH > maxH)
			{
				newH = maxH;
				newW = newH / ratio;
			}
		}
		
		return [newW, newH];
	}
	
	// Constructor
	
	managedImages = images;
	for (var i = 0; i < managedImages.length; i++)
	{
		var el = managedImages[i];
		if (el.addEventListener)
		{
			el.addEventListener("click", onImageClick, false);
		}
		else if (el.attachEvent)
		{
			el.attachEvent("onclick", onImageClick);
		}
		else
		{
			el.onclick = onImageClick;
		}
	}
	
	state = new Array(images.length);
	for (var i = 0; i < state.length; i++)
	{
		state[i] = 1; // normal
	}
	
	smallW = 500;
	smallH = 100;
}