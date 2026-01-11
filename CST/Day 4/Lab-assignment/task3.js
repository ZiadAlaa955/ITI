function showLargestWord(s) {
  var largestWord = "";
  var words = s.split(" ");

  for (var i = 0; i < words.length; i++) {
    if (largestWord.length < words[i].length) largestWord = words[i];
  }

  return largestWord;
}

console.log(showLargestWord("this is a typescript javascript string demo"));
