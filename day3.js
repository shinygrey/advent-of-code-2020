const fs = require('fs');

const data = fs.readFileSync('./day3_input.txt','utf-8');
const lines = data.split('\n');

function traverse(rightn,down) {
	return  lines.reduce((acc,line,i) => {
		if(i % down !== 0 || i === 0){
			return acc;
		}else{
			var right = Math.floor(rightn / down);
			var multi = Math.ceil(((i * right)+1) / line.length);
			var point = line[(i * right) - ((multi-1) * line.length)];
			if(point === '#'){
				return acc + 1;
			}else{
				return acc;
			}
		}
	},0);
}

var part1answer = traverse(3,1);

var slopes = [[1,1],[3,1],[5,1],[7,1],[1,2]]

var part2answer = slopes.reduce((acc,slope,i) => {
	var trees = traverse(slope[0],slope[1]);
	console.log(i,trees);
	return acc * trees;
},1)

console.log('part 1',part1answer);
console.log('part 2',part2answer);
//2908550400, 2985091200 too high ... 2678928000