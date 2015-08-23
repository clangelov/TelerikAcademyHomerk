/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve() {

    return function (students) {
        var highestScoredStudent = _.chain(students)
            .map(function (student) {
                var totalScore = _.reduce(student.marks, function (totalScore, mark) {
                    return totalScore + mark;
                }, 0);
                var averageScore = totalScore / student.marks.length;
                student.averageScore = averageScore;
                return student;
            })
            .sortBy('averageScore')
            .last()
            .value();

        var result = highestScoredStudent.firstName + ' ' + highestScoredStudent.lastName + ' has an average score of ' + highestScoredStudent.averageScore;
        console.log(result);
    };
}

module.exports = solve;
