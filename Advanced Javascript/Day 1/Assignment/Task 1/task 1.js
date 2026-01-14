let linkedListObj = {
  data: [{ val: 2 }, { val: 4 }],
  Enqueue: function (x) {
    if (this.data[0].val > x || this.data.length == 0) {
      this.data.unshift({ val: x });
    } else {
      throw "this value cannot be enqueued";
    }
  },
  push: function (x) {
    if (this.data[this.data.length - 1].val < x || this.data.length == 0) {
      this.data.push({ val: x });
    } else {
      throw "this value cannot be pushed";
    }
  },
  Insert: function (x, pos) {
    if (this.data.length == 0) {
      this.data.push({ val: x });
    } else {
      let isInserted = false;
      for (let i = 0; i < this.data.length; i++) {
        if (this.data[i].val > x) {
          if (pos == i + 1) {
            this.data.splice(i, 0, { val: x });
            isInserted = true;
            break;
          } else {
            throw "This is a duplicated value";
          }
        } else if (this.data[i].val < x) {
          continue;
        } else if (this.data[i].val == x) {
          throw "This is a duplicated value";
        }
      }
      if (isInserted == false) {
        this.data.push({ val: x });
      }
    }
  },
  Dequeue: function () {
    this.data.shift();
  },
  Pop: function () {
    this.data.pop();
  },
  Remove: function (x) {
    let isRemoved = false;
    for (let i = 0; i < this.data.length; i++) {
      if (this.data[i].val == x) {
        isRemoved = true;
        this.data.splice(i, 1);
        break;
      }
    }
    if (isRemoved == false) {
      throw "Data not found";
    }
  },
  DiplayAll: function () {
    for (let i = 0; i < this.data.length; i++) {
      console.log(this.data[i].val);
    }
  },
};

linkedListObj.push(10);
linkedListObj.Enqueue(1);
linkedListObj.Insert(3, 3);
linkedListObj.DiplayAll();
