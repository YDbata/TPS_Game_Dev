# 3D TPS Game
TPS 게임 제작 구현

## 주요 작업
- 3D 환경에서 캐릭터 구현
- Enemy 구현
- UI 구성
- 퀘스트 구성
- 카메라 조절
- 기타

## 캐릭터 구현

### 캐릭터 기본 조작
<img src="https://github.com/YDbata/TPS_Game_Dev/assets/51112432/01976700-9884-40af-b136-3e74d711576f" width=400>

기본이동 및 점프 : input maneger로 구현  
<img src="https://github.com/YDbata/TPS_Game_Dev/assets/51112432/52f8b499-2a0c-4234-8aa9-7ad49ba59622" width=400>

기타 상호작용 : Script 내 코드로 구현

### 무기
총에 별도 스크립트를 넣어서 제작  
| 이후 Enemy 코딩때는 발전시켜 ShootState 스크립트를 캐릭터에 직접 작성하였다.

### 에니메이션
기본 이동 : 서기 - 걷기 - 뛰기 블랜딩 이용 에니메이션
에임 조준, 발사 에니메이션 추가
<img src="https://github.com/YDbata/TPS_Game_Dev/assets/51112432/35748c03-d2a8-4bba-bf5b-7fc9bb8a6674" width=800>

## Enemy 구현
### Soldier
기본 Player의 틀에서 Patrol과 Chase, Shoot 기능을 따로 넣어 구현하였다.
- Patrol : Game Object로 WayPoint를 임무 지역내 여러 곳을 만들어 두고 일부 지점을 순찰하는 방식
- Chase : Player에게 피격을 당하거나 Player가 가까이 다가왔을 때, Player를 추격하는 형태
- Shoot : Player의 무기처럼 무기가 바뀌지 않으므로 총에 따로 스크립트를 삽입하지 않고 캐릭터에서 처리하는 형태

### Turret
Patrol 없이 가만히 있는 개체

### Dron
공중 공격을 하는 개체(미완성)

## UI 구성

### Health Bar
- 기본 HP Bar

### 탄창, 탄약 개수 표시
- Mag(탄창), Ammo(탄약) 개수를 표시하고 사용할 때 마다 업데이트

### 나침반
- 상단에서 현재 방위를 표시하여 Player가 위치를 특정할 때 도움을 준다.

### 퀘스트 리스트 표시
- Q를 누르면 현재 퀘스트가 표시되며 완료시 표시 Text와 색이 바뀐다.

### 메뉴 리스트 표시
- 일시 정지, 돌아가기, 메인메뉴와 같은 메뉴를 표시한다.

### 미니맵(미완성)

## 퀘스트 구현
### 키를 집고 문열기

### 컴퓨터 작동해제

### Generator 작동 해제

### 준비된 차에 탑승

## 카메라 조절
카메라를 TPS에 맞게 캐릭터 뒤에서 캐릭터를 follow하도록 설정

