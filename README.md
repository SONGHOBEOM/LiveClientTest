# [사전테스트] 라이브 클라이언트 프로그래머_송호범_과제

#### 안녕하십니까 이번 라이브 클라이언트 프로그래머에 지원한 송호범입니다.
#### 제가 이번 과제에 임하면서 가장 중요하게 생각한 것은 아래의 두 가지입니다.
    1. 데이터와 로직 분리 
    2. 객체 지향 설계 원칙에 기반한 구조
    3. 협업을 고려한 개발 편의성 제공
##### 데이터와 로직을 분리하고 캡슐화 함으로서 시스템의 유지보수, 확장성을 용이하게 하였습니다.
##### 또한, 단일 책임 원칙에 근거하여 각각의 버프객체가 각자의 로직만을 수행하기 때문에 높은 응집도를 갖도록 하였습니다.

##### 게임 개발은 프로그래머 혼자서 진행하는 것이 아닌 팀원들과의 협업으로 이루어집니다.
##### 특히, 대부분의 협업을 진행하는 기획자가 직접 연산자와 값을 넣어서 간단한 버프들은 쉽게 개발할 수 있도록 Scriptable Object Data를 Inspector에서 쉽게 추가 및 수정할 수 있도록 하였습니다.
<img width="531" alt="inspector" src="https://github.com/user-attachments/assets/78cbcbe0-b332-4a66-801e-fca383f3be41" />

##

#### 과제에 대한 제 코드를 보시기 편하도록 하단에 폴더명을 중심으로 정리하였습니다.
#### 잘 부탁드립니다!

## 

### [Scripts/Data] 
#### https://github.com/SONGHOBEOM/LiveClientTest/tree/main/Game/Assets/Game/Scripts/Data
#### Game에서 사용하는 Effect ScriptableObject를 생성하는 Script입니다.

##

### [Scripts/Effect] 
#### https://github.com/SONGHOBEOM/LiveClientTest/tree/main/Game/Assets/Game/Scripts/Effect
#### Effect와 관련된 Script입니다. 
#### 과제 2> 리팩토링 (ApplyEffect)와 관련된 코드는 Effect class의 ApplyEffect() 를 확인해주시면 감사하겠습니다.

##

### [Scripts/Singleton] 
#### https://github.com/SONGHOBEOM/LiveClientTest/tree/main/Game/Assets/Game/Scripts/Singleton
#### Singleton 패턴과 Manager class를 구현한 Script입니다.

##

### [Scripts/Player] 
#### https://github.com/SONGHOBEOM/LiveClientTest/tree/main/Game/Assets/Game/Scripts/Player
#### Player의 움직임과 Player가 Effect Item을 획득했을 때, EffectData를 어떻게 다루는지를 구현한 Script입니다.

##

### [Video Link]
#### https://youtu.be/w_bq9fNjy9Y
#### 과제 시연 영상 링크입니다.

##

### 이상입니다. 귀한 시간 내주셔서 감사합니다.
