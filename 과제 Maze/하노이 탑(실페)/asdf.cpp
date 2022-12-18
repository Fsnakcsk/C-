/*
가끔 가다가 별표가 출력 되지 않는 경우가 있더군요.
이럴 때는 한번 다른 문자로 바꾼 다음에 다시 시도해보세요.
*/

 

#include <stdio.h>

 

#define MAX_SIZE 10

 

int fromTop;
int tempTop;
int toTop;

 

int fromPole[MAX_SIZE];
int tempPole[MAX_SIZE];
int toPole[MAX_SIZE];

 

int move_count = 0; // 원반을 옮긴 횟수를 출력 해줄 변수 입니다.

int getDiskNum();


void initializeDisk(int diskNum);
void moveHanoi(int disks, char from, char temp , char to);
void moveDisk(char from, char to);
void drawAllDisks();

 

 

int main(void)
{
 int diskNum = getDiskNum(); //함수를 통해 사용자로부터 디스크 수를 입력 받는다.

 while(diskNum > 0)
 {
  initializeDisk(diskNum); //함수를 통해 각각의 말뚝에 해당하는 배열들을 초기화한다.(배열은 전역변수)
  
  drawAllDisks(); //함수를 통해 초기화된 말뚝의 모습을 그린다.
  
  moveHanoi(diskNum, 'A', 'B', 'C'); // 재귀함수를 통해 디스크들을 옮긴다.
 
  move_count=0;

  diskNum = getDiskNum(); //함수로 다시 사용자로부터 디스크 수를 입력 받아 프로그램을 반복 수행한다.
 }

 return 0;
}

 

 

int getDiskNum()
{ //사용자로부터 디스크 개수를 입력 받는다. 1이상 MAX_SIZE이하
 int loop = 1;
 int dish = 0;

 while(loop == 1)
 {
  printf("하노이 원반 수를 입력하시오. 값 : [1<= X <=10]\n단, -1을 입력하면 프로그램은 종료 됩니다. : \n");

  fflush(stdin);
  scanf("%d" ,&dish);

  if( (dish >= 1) && (dish <=10) )
  { printf("%d개의 원반으로 프로그램을 실행 합니다.\n",dish);
   loop = 0; }

  else if(dish == -1)
  { printf("프로그램을 종료 시킵니다.\n");
   loop = 0; }

  else // 비정상 값을 입력 하면 반복문을 다시 돌도록 합니다.
  { printf("범위가 올바르지 않습니다. 다시 입력하시오.\n");
   loop = 1; }
 }
 return dish;
}

 

 

 

void initializeDisk(int diskNum)
{
 /*사용자가 초기 입력한 원반의 수에 따라 각각의 말뚝을 초기화 하는 함수
 첫번째 인자: 사용자가 입력한 디스크 수*/
 
 int i = 0;
   
 fromTop = diskNum; // 원반의 개수
 tempTop = 0;
 toTop = 0;

 while(i <= MAX_SIZE) // 초기화
 { fromPole[i] = 0;
  tempPole[i] = 0;
  toPole[i] = 0;
  ++i; }
 
 i=0;
 while( i < fromTop) // 원반의 개수에 해당되는 숫자를 저장합니다.
 { fromPole[i] = (diskNum - i); //인덱스 값이 +1 되면 배열에 저장되는 수는 -1 됩니다.
  ++i; }

}

 

 

 

void moveHanoi(int disks, char from, char temp , char to)
{
/*재귀적 문제 해결규칙에 맞게 재귀함수를 구현한다
첫번재 인자: 옮기려는 원반의 수
두번째 인자: 출발 말뚝에 해당 하는 문자
세번째 인자: 중간이용 말뚝의 이름
네번재 인자: 목적 말뚝의 이름

1번규칙 : n-1개의 원반을 중간말뚝에 이동
2번규칙 : 출발 말뚝의 가장 마지막 하부의 제일 큰 원반을 목적말뚝에 이동
3번규칙 : 중간말뚝에 있는 n-1개의 원반을 목적말뚝으로 이동*/
  

 if(disks == 1)
 { ++move_count;
  printf("%5d: 말뚝 %c에서 말뚝 %c로 원반 %d를 이동\n", move_count, from, to, 1);
  moveDisk(from, to); }
 else
 { moveHanoi(disks-1, from, to, temp);    // 1번규칙 적용
  ++move_count;
  printf("%5d: 말뚝 %c에서 말뚝 %c로 원반 %d를 이동\n", move_count, from, to, disks);  // 2번규칙 적용
  moveDisk(from, to);
  moveHanoi(disks-1, temp, from, to);  // 3번규칙 적용
 }
}

 

 

 

void moveDisk(char from, char to)
{ /*
 함수를 구현하여 각각의 배열에 저장된 값과 top index를 디스크의 이동에 따라 옮긴다.
 디스크 이동후의 모습을 drawAllDisks()함수를 통해 그린다.

 3개의 말뚝에 해당하는 배열안에 저장되어 있는 디스크들을 이동시키는 함수.
 첫번재 인자: 출발 말뚝에 해당 하는 문자
 두번째 인자: 목적 말뚝에 해당 하는 문자
 */
 
 int *FROM, *TO; //포인터를 지정합니다. 매개변수 인자의 값에 따라 가르키는 값이 다르게 됩니다.
 int From_index, To_index; // 배열에 값을 옮길 때 쓰일 임시 변수입니다.
 
 if(from == 'A')
 { FROM = fromPole;
  From_index = fromTop--; }
 else if(from == 'B')
 { FROM = tempPole;
  From_index = tempTop--; }
 else
 { FROM = toPole;
  From_index = toTop--; }
  
 if(to == 'A')
 { TO = fromPole;
  To_index = fromTop++; }
 else if(to == 'B')
 { TO = tempPole;
  To_index = tempTop++; }
 else
 { TO = toPole;
  To_index = toTop++; }

 TO[To_index] = FROM[From_index - 1]; //배열에 값을 쓴 후에
 FROM[From_index - 1] = 0; // 이전에 있던 배열에서는 0으로 삭제 합니다.
 
 drawAllDisks();
}

 

 

 

void drawAllDisks()
{
 /*
 각각의 배열을 참조하여 “*” 모양으로 탑 모양을 그려주는 함수.
 그리는 알고리즘은 3개의 말뚝 크기 중 가장 큰 것을 기준으로 그 만큼 반복하면서
 각각의 배열의 가장 위의 인덱스에 있는 값부터 하나씩 가져와 그 값만큼 반복하면서
 “*”을 프린트 하는 2중 반복문 형태로 구현 하면 된다.
 */
 
 int j = 1;
 int tower_height = ( (fromTop >= tempTop) ? fromTop : tempTop );
 tower_height = ( (toTop >= tower_height) ? toTop : tower_height);
 // 최대 값을 결정합니다. 이 값은 원반을 출력시 높낮이를 결정합니다.

 while( tower_height >= 0) //행의 역할을 한다. (tower_height -> 0  인덱스 순으로 부터 출력한다.)
 {  
  j=1;
  while( j <= fromPole[tower_height] )
  { printf("*"); j++; }
  printf("\t\t");
  
  j=1;
  while( j <= tempPole[tower_height] )
  { printf("*"); j++; }
  printf("\t\t");

  j=1;
  while( j <= toPole[tower_height] )
  { printf("*"); j++; }
  printf("\n");

  tower_height--;
 }
 printf(" -----A-----\t-----B-----\t-----C-----\n\n\n");
