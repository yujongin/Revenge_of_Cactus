# Revenge_of_Cactus
#운동 게임, #동작 인식, #Unity3D 


## 📜 프로젝트 소개 
 - 코로나 시대에 집에서 몸을 움직이며 건강하게 즐길 수 없을까? 라는 고민에 만들게 된 게임입니다.
 - 다른 RPG게임과는 다르게 게임속 몬스터를 사냥하거나 캐릭터를 성장 시킬때 사용자가 직접 몸을 움직여 공격을 하거나 수비를하고, 몬스터의 필사기패턴을 강도 높은 운동을 함으로써 파회하는 게임으로 제작하였습니다.

## ⌚ 개발 기간
* 2021.05 ~2021.08

## 👨🏿‍🤝‍👨🏿 제작 맴버
 - 하태성 : 게임 환경 제작, Open-Pose로 운동 감지 제작
 - 유종인 : 게임 환경 제작, 스토리 제작
 - 강민수 : 게임 환경 제작, 운동 관련 정보 수집
   
## 🛠 개발 환경
- C#     
- Unity
- python
- pytorch

## 🏆 경남 SW 경진대회에서 최우수상을 수여하였습니다.🎊🎊



# 🎥지금부터 설명을 시작하겠습니다.
![최종발표_1](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/12061b8e-77b4-48ba-a919-59c23325f257)
![최종발표_2](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/9c58d7da-a23a-4ab2-8a91-204a423d343f)
 - 저희 게임에 대해 간단하게 요약을 하자면 사용자가 직접 맨몸운동을 함으로써 게임 캐릭터의 스탯을 향상시키고, 이후 몬스터를 사냥할때도 사용자의 모션을 감지하여 공격과 방어를 진행하게 됩니다.

![최종발표_3](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/4f5ff816-7a19-422e-bec1-f0fe9c1998cd)
![최종발표_4](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/c2698cba-80ae-4bc9-a430-7a24a4bd1c26)
 - Revenge_Of_Cactus를 만들게 동기는 코로나를 겪으며 재택근무가 많아지게되고 움직이지않자 비만과 같은 문제가 계속해서 커져가고있었습니다.

![최종발표_5](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/bcae434d-f725-4c51-96b1-dfff3b5f97b7)
 - 이러한 문제는 신체적 건강 뿐만 아니라 심리적 건강까지 해치게 되었고,

![최종발표_6](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/a3e8f8b2-8dc1-4863-bf53-3120d736a7f5)
 - 그렇다 보니 코로나 이후 학생들의 성정과 생활 만족도도 크게 떨어지게 되는 모습을 보여주었습니다.

![최종발표_7](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/699a02bd-4be3-4dc4-9f66-67bd03f0726a)
 - 이걸 보면 헬스가 필요한건 맞지만 헬스장에도 코로나 바이러스가 퍼지게 되면서 헬스장도 가기 어려워 졌습니다.
   
![최종발표_8](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/c1dd82fe-cb2a-4a6a-b5ee-6e0cc2ec8463)
 - 그래서 학생들이 운동을 게임처럼 즐겁게 하면서 건강도 찾고 생활 만족도를 올리는 게임을 만들기로 했습니다.
   
![최종발표_9](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/a64c84d4-7da1-414f-b3e4-d82c825bf449)
![최종발표_10](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/73cec175-fbf7-403b-b9dd-10b20078c005)
 - 개발 환경은 C#과 유니티를 활용하여 제작하였고 openpose를 연동시키기 위해 python과 pytorch를 사용하였습니다.
   
![최종발표_11](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/35aad29c-26aa-4550-9897-1c13297552f2)
 - 저희는 이형원 교수님과 김경이 교수님의 지도를 받아 진행하였습니다.
   
![최종발표_12](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/7f575d9b-1032-4ea9-b75b-31855b7d29c5)
![최종발표_13](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/8de4a113-9c7f-4d5b-b03c-19a1a6e058c3)
 - 게임은 웹 캠으로 들어온 이미지를 open pose로 사람을 인식하고 동작을 판단하여 현재 운동의 시간 및 개수를 계산합니다.
 - 이후 게임의 전반적인 진행은 ppt안에 글을 읽어주시면 감사하겠습니다.

![최종발표_14](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/e08bb7d6-8455-4230-9a05-4ce05eefb530)
![최종발표_15](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/ea572b7a-603a-4ba5-9c57-6f79ba1bd932)
![최종발표_16](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/d460fdcd-13f0-4f33-be52-cd542a267df3)
![최종발표_17](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/752f4d69-96a8-41bf-ad0a-ae5bf4618773)
![최종발표_18](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/d8a98442-a31f-499d-b5ad-926b480d71ee)
![최종발표_19](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/36e4d2df-8c08-4f6c-91a3-924480172a63)
![최종발표_20](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/e1a09099-90d6-4daa-bab9-95c9e7f1c6e9)
![최종발표_21](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/5ef1b26a-cadf-424f-899c-8e3bb9bf8857)
![최종발표_22](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/5dd5ad5e-f124-4c23-91eb-e16c743f4d9c)
![최종발표_23](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/50c71aec-ba3c-4bfa-95e0-873753aa8444)
![최종발표_24](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/56ee7819-c28d-4459-aaac-adfb730a1149)
![최종발표_25](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/3b655b55-1fcb-4564-890b-19abeed00fbd)
![최종발표_26](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/9159f790-eb48-4008-b204-202087143f25)
![최종발표_27](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/1c8948b5-e4e7-4d52-8686-27c70af92646)
![최종발표_28](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/b35ebe81-1e7f-478a-98d6-715b44ed8506)
![최종발표_29](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/49b80a1e-0bfe-4e8c-8f07-b98683542eda)
![최종발표_30](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/03b772e6-c6e1-4773-b3ef-5a548d24dbc4)
![최종발표_31](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/c6f688a8-c9b1-4545-83d9-ec198ba9fa94)
![최종발표_32](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/c1060b12-65b5-4bd4-b878-960bf360eec1)
![최종발표_33](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/ab47d728-b02e-4721-bae2-f0ee74e43620)
![최종발표_34](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/f46307dd-0737-4d87-bc61-52706e0dd23a)
![최종발표_35](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/9f6af012-06d9-4f70-a2d6-3079fdf4bc9d)
![최종발표_36](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/5b2afd33-77e8-4f6b-a1a9-5e7da0e0388f)
 - 시연 영상을 잃어 버려서 진행을 보여드리지 못하는 점 죄송합니다.
![최종발표_37](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/e62cefd3-23f2-442e-b0d8-a13cbd9a9a85)
![최종발표_38](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/2addb93f-b475-4a57-9222-747b8e0bd32b)
![최종발표_39](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/426bfe12-7a62-4e9d-8c07-5b85ce1e721d)
![최종발표_40](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/d78f9778-d134-44d4-8819-b9f304805a8a)
 - 이후 게임을 휴대폰이나 다른 플랫폼에서 사용할 수 있게 만들려고 하였고 멀티를 생각했지만 서로 사회로 나가버려 프로젝트는 여기서 막을내렸습니다. 지금까지 봐주셔서 감사합니다.

![최종발표_41](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/6b2ed4e7-265a-4ed3-afe0-43405448e2b0)
![최종발표_42](https://github.com/gkxotjd12312/Revenge_of_Cactus/assets/54784059/47730cca-7586-4465-bb00-06a9bf171ddd)

