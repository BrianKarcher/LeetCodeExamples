var createCounter = function(n) {
    var current = n;
    return function() {
        var rtn = current;
        current++;
        return rtn;
    };
  };

  const counter = createCounter(10)
  console.log(counter());
  console.log(counter());