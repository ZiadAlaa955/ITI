db.Course.aggregate([
  {
    $group: {
      _id: null,
      FinalMarksSum: {
        $sum: "$Final Mark",
      },
    },
  },
  {
    $project: {
      _id: 0,
      FinalMarksSum: 1,
    },
  },
]);