/**
 * QuickSort Implementation with Detailed Comments
 * ================================================
 *
 * QuickSort is a divide-and-conquer algorithm that works by:
 * 1. Selecting a 'pivot' element from the array
 * 2. Partitioning: rearranging elements so smaller ones are left of pivot,
 *    and larger ones are right of pivot
 * 3. Recursively applying the same process to left and right partitions
 */

// DOM Elements
const numberInput = document.getElementById("numberInput");
const sortButton = document.getElementById("sortButton");
const resultArea = document.getElementById("resultArea");
const resultContent = document.getElementById("resultContent");
const errorMessage = document.getElementById("errorMessage");

/**
 * Parses and validates user input
 * @param {string} input - Raw user input string
 * @returns {number[]|null} - Array of numbers or null if invalid
 */
function parseInput(input) {
  // Check for empty input
  if (!input || input.trim() === "") {
    showError("Please enter some numbers to sort.");
    return null;
  }

  // Trim whitespace and split by comma
  const parts = input.split(",");

  // Check for empty segments (e.g., "1,,2" or ",1,2")
  if (parts.some((part) => part.trim() === "")) {
    showError(
      "Invalid input: empty values detected. Please use format: 1, 2, 3",
    );
    return null;
  }

  // Parse each part as a number
  const numbers = [];
  for (let i = 0; i < parts.length; i++) {
    const trimmed = parts[i].trim();

    // Check if the trimmed part is a valid number
    // isNaN() returns true for non-numeric strings like "abc" or ""
    // We also check that it's not just whitespace
    if (trimmed === "" || isNaN(trimmed)) {
      showError(
        `Invalid input: "${trimmed}" is not a valid number. Please enter only numbers.`,
      );
      return null;
    }

    // Parse the number (handles integers and decimals)
    const num = Number(trimmed);

    // Check for Infinity (too large numbers)
    if (!isFinite(num)) {
      showError(`Invalid input: "${trimmed}" is too large or invalid.`);
      return null;
    }

    numbers.push(num);
  }

  return numbers;
}

/**
 * Shows error message to user
 * @param {string} message - Error message to display
 */
function showError(message) {
  errorMessage.textContent = message;
  errorMessage.classList.add("visible");
  numberInput.classList.add("error");
  resultArea.classList.remove("visible");
}

/**
 * Clears error state
 */
function clearError() {
  errorMessage.classList.remove("visible");
  numberInput.classList.remove("error");
}

/**
 * Displays sorted result with animation
 * @param {number[]} sortedArray - The sorted array to display
 */
function displayResult(sortedArray) {
  resultContent.innerHTML = "";

  // Create badge elements for each number with staggered animation
  sortedArray.forEach((num, index) => {
    const badge = document.createElement("span");
    badge.className = "number-badge";
    badge.textContent = num;
    // Stagger the animation delay for each element
    badge.style.animationDelay = `${index * 0.05}s`;
    resultContent.appendChild(badge);
  });

  resultArea.classList.add("visible");
}

/**
 * QuickSort Main Algorithm
 * ========================
 *
 * This function initiates the QuickSort process.
 * It creates a copy of the array to avoid mutating the original,
 * then calls the recursive partition function.
 *
 * @param {number[]} arr - The array to sort
 * @returns {number[]} - A new sorted array
 */
function quickSort(arr) {
  // Edge case: arrays with 0 or 1 element are already sorted
  if (arr.length <= 1) {
    return arr; // Return copy of single element or empty array
  }

  // Create a shallow copy to avoid mutating the original array
  const arrCopy = [...arr];

  /**
   * Partition Function
   * ==================
   * This is the core of QuickSort. It:
   * 1. Selects a pivot (we use the last element)
   * 2. Rearranges elements so all smaller values are on the left
   * 3. Returns the final position of the pivot
   *
   * @param {number[]} array - The array (or subarray) to partition
   * @param {number} low - Starting index of the partition
   * @param {number} high - Ending index of the partition (pivot's index)
   * @returns {number} - The final position of the pivot
   */
  function partition(array, low, high) {
    // Select the pivot element (last element in current subarray)
    // This is a simple pivot selection strategy
    const pivot = array[high];

    // 'i' tracks the boundary for elements smaller than pivot
    // Initialize to one position before the start
    let i = low - 1;

    // Iterate through all elements except the pivot
    for (let j = low; j < high; j++) {
      // If current element is smaller than or equal to pivot
      if (array[j] <= pivot) {
        i++; // Increment the boundary

        // Swap array[i] and array[j]
        // This moves smaller elements to the left partition
        const temp = array[i];
        array[i] = array[j];
        array[j] = temp;
      }
    }

    // Place the pivot in its correct sorted position
    // All elements to the left are <= pivot
    // All elements to the right are > pivot
    const temp = array[i + 1];
    array[i + 1] = array[high];
    array[high] = temp;

    // Return the pivot's final position
    return i + 1;
  }

  /**
   * Recursive QuickSort Function
   * ============================
   * Applies QuickSort to subarrays:
   * 1. Partition the current subarray
   * 2. Recursively sort the left partition (elements < pivot)
   * 3. Recursively sort the right partition (elements > pivot)
   *
   * @param {number[]} array - The array to sort
   * @param {number} low - Starting index
   * @param {number} high - Ending index
   */
  function quickSortRecursive(array, low, high) {
    // Base case: if there's more than one element to sort
    if (low < high) {
      // Partition the array and get the pivot's final position
      const pivotIndex = partition(array, low, high);

      // Recursively sort the left subarray (elements before pivot)
      // Note: pivotIndex - 1 because pivot is now in its final position
      quickSortRecursive(array, low, pivotIndex - 1);

      // Recursively sort the right subarray (elements after pivot)
      quickSortRecursive(array, pivotIndex + 1, high);
    }
    // If low >= high, the subarray has 0 or 1 element - already sorted
  }

  // Start the recursive QuickSort on the entire array
  quickSortRecursive(arrCopy, 0, arrCopy.length - 1);

  return arrCopy;
}

/**
 * Handles the sort button click event
 */
function handleSort() {
  // Clear any previous errors
  clearError();

  // Get and validate input
  const input = numberInput.value;
  const numbers = parseInput(input);

  // If validation failed, numbers will be null
  if (numbers === null) {
    return;
  }

  // Handle edge case: empty array after parsing
  if (numbers.length === 0) {
    showError("Please enter at least one number.");
    return;
  }

  // Handle edge case: single element array
  if (numbers.length === 1) {
    displayResult(numbers);
    return;
  }

  // Run QuickSort algorithm
  const sorted = quickSort(numbers);

  // Display the result
  displayResult(sorted);
}

// Event Listeners
sortButton.addEventListener("click", handleSort);

// Allow pressing Enter to trigger sort
numberInput.addEventListener("keypress", function (e) {
  if (e.key === "Enter") {
    handleSort();
  }
});

// Clear error when user starts typing
numberInput.addEventListener("input", function () {
  clearError();
});

/*
 * QUICKSORT COMPLEXITY ANALYSIS
 * =============================
 *
 * TIME COMPLEXITY:
 * ----------------
 * • Best Case:   O(n log n) - When pivot divides array into two equal halves
 * • Average Case: O(n log n) - Random or balanced partitions
 * • Worst Case:  O(n²) - When pivot is always smallest/largest element
 *                (already sorted array, sorted in ascending/descending order)
 *
 * SPACE COMPLEXITY:
 * -----------------
 * • O(log n) - For the call stack in average case (balanced recursion)
 * • O(n) - In worst case due to recursion stack depth
 *
 * QUICKSORT vs OTHER ALGORITHMS:
 * ==============================
 *
 * | Algorithm    | Best       | Average    | Worst      | Space   | Stable |
 * |--------------|------------|------------|------------|---------|--------|
 * | QuickSort    | O(n log n) | O(n log n) | O(n²)      | O(log n)|   No   |
 * | MergeSort    | O(n log n) | O(n log n) | O(n log n) | O(n)    |  Yes   |
 * | HeapSort     | O(n log n) | O(n log n) | O(n log n) | O(1)    |   No   |
 * | Array.sort() | O(n log n) | O(n log n) | O(n log n) | O(log n)|  Yes*  |
 *
 * * JavaScript's sort() is stable in modern engines (V8, SpiderMonkey)
 *
 * KEY CHARACTERISTICS:
 * ====================
 *
 * QuickSort:
 * ✓ In-place sorting (low space overhead)
 * ✓ Cache-efficient due to sequential memory access
 * ✓ Not stable (equal elements may change relative order)
 * ✓ Excellent for average case scenarios
 * ✗ Worst-case can degrade to O(n²) - mitigated with random pivot
 *
 * MergeSort:
 * ✓ Stable sorting algorithm
 * ✓ Guaranteed O(n log n) performance
 * ✓ Excellent for linked lists
 * ✗ Requires O(n) extra space
 *
 * HeapSort:
 * ✓ Guaranteed O(n log n) time
 * ✓ In-place (O(1) space)
 * ✗ Not cache-friendly (non-sequential access)
 * ✗ Not stable
 *
 * JavaScript Array.sort():
 * ✓ Optimized implementation (typically TimSort or MergeSort)
 * ✓ Stable in modern browsers
 * ✓ Handles edge cases gracefully
 * ✓ Accepts custom comparison function
 *
 * RECOMMENDATION:
 * ===============
 * For general-purpose sorting in JavaScript, use the built-in
 * Array.prototype.sort() - it's optimized, stable, and handles
 * edge cases. Implement QuickSort for learning purposes or when
 * in-place sorting with minimal memory overhead is critical.
 */
