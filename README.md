# Matmex_Quest
Авторы: Гордиенко Артем и Айдарцян Гриша
## Описание:
Игра представляет собой 2д квест. Игрок перемещается по комнатам, взаимодействует с другими персонажами, собирает предметы. Цель игры - выполнить все задания и сдать экзамены.

## Управление:
* W, A, S, D - перемещение
* E - кнопка взаимодействия с коружающим миром
* Левая кнопка мыши - сбор предметов

## Подробности реализации
Все модели игры находятся в папке Domain. Также есть модульные тесты, покрывающие на данный момент 97 % кода.
Описание моделей:
* Door - двери в нашем мире, и их привязка к комнатам. Также содержит состояния Open и Close.
* Human - персонажи, которые дают квест, а именно их локацию, состояние (готов дать квест, не готов дать квест, ждет когда мы выполним квест) и список предметов, которые они от нас ожидают
* Inventory - инвентарь игрока, который содержит в себе предметы, собранные игроком. Мы можем класть вещи в инвентарь и брать их из него. Может стакать предметы.
* Item - предмет, который можно отдать или взять. Описывается своей локацией, типом (objectID), размерами и привязкой к определенному квесту (missionID).
* Player - персонаж, которым управляет игрок. Имеет несколько состояний (жив, мертв) и умеет передвигаться.
* Room - комнаты, содержащие в себе персонажей, дающих квесты и предметы, которые можно собрать.
* World - игровой мир (корридор матмеха), в котором хранятся двери, которые указывают нам на комнаты, люди и предметы.

В проекте TESTS хранятся все тесты. В кодовом файле TestGame происходит иммитация игрового процесса со всеми доступными действиями.
