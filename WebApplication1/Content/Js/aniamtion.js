// Detect request animation frame
var scroll = window.requestAnimationFrame ||
             // IE Fallback
             function(callback){ window.setTimeout(callback, 1000/60)};
var elementsToShow = document.querySelectorAll('.show-on-scroll'); 


function loop() {

    Array.prototype.forEach.call(elementsToShow, function(element){
      if (isElementInViewport(element)) {
        element.classList.add('is-visible');
      } 
    });

    scroll(loop);
}

// Call the loop for the first time
loop();

// Helper function from: http://stackoverflow.com/a/7557433/274826
function isElementInViewport(el) {
  // special bonus for those using jQuery
  if (typeof jQuery === "function" && el instanceof jQuery) {
    el = el[0];
  }
  var rect = el.getBoundingClientRect();
  return (
    (rect.top <= 0
      && rect.bottom >= 0)
    ||
    (rect.bottom >= (window.innerHeight || document.documentElement.clientHeight) &&
      rect.top <= (window.innerHeight || document.documentElement.clientHeight))
    ||
    (rect.top >= 0 &&
      rect.bottom <= (window.innerHeight || document.documentElement.clientHeight))
  );
}



const counters = document.querySelectorAll('.number');


counters.forEach(counter => {
	const updateCount = () => {
		const target = +counter.getAttribute('data-number');
		const count = +counter.innerText;

		// Lower inc to slow and higher to slow
	//const inc = target / speed;
        //console.log(target);
		//console.log(inc);
		// console.log(count);

		// Check if target is reached
		if (count < target) {
			// Add inc to count and output in counter
            if(target>1000)
            {
              counter.innerText = count+9;
            }
            else{
              counter.innerText = count+1;
            }
			// Call function every ms
			setTimeout(updateCount, (18/target)*500);
		} else {
			counter.innerText = target;
		}
	};

	updateCount();
});

