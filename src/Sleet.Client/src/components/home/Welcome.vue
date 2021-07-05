<template>
  <div class="container mx-auto md:w-2/4 w-11/12">
    <div>
      <h1 class="text-center mt-5 text-5xl mb-5">请认真阅读如下说明</h1>
    </div>

    <div>
      <h2 class="mt-5 text-3xl">翻译项目简介</h2>
      <ul class="mt-2 list-inside list-disc text-lg text-gray-500 mb-5">
        <li>
          Minecraft
          模组汉化项目是开源、非盈利的项目，所做的汉化全都公开发行，供所有玩家使用。
        </li>
        <li>
          本项目采用
          <a href="https://creativecommons.org/licenses/by-nc-sa/4.0/deed.zh" class="url-info">
            知识共享署名-非商业性使用-相同方式共享 4.0
            国际许可协议（简体中文）
          </a>
          进行许可。
        </li>
        <li>
          汉化项目目前是基于 CurseForge 网站，选取 1.12.2/1.16.5
          版本，按照热度下载了近千模组，基本上能覆盖了绝大部分玩家的日常模组。
        </li>
        <li>
          如果你有什么想要额外添加翻译的模组或者整合，请通过首页的
          <a href="https://ticket.cyllive.cn/" class="url-info">问题反馈中心</a>
          进行提交。
        </li>
        <li>
          请在参与翻译前认真阅读了
          <a href="https://rules.cfpa.team/" class="url-info">翻译规范</a> 与
          <a href="https://weblate-guide.cfpa.team/" class="url-info">Weblate 使用说明</a>，如果部分内容难以理解，可以先跳过。
        </li>
        <li>目前开放了两种群组，你可以选择加入 QQ 群（推荐）或者 Discord 群。</li>
        <li>汉化完毕后，会被系统自动处理，打包做成资源包，上传到云服务器上。其他使用了汉化模组玩家，在启动游戏时就会自动下载最新版汉化。</li>
      </ul>
    </div>

    <div>
      <h2 class="mt-5 text-3xl">翻译项目规范</h2>
      <ul class="mt-2 list-inside list-disc text-lg text-gray-500 mb-5">
        <li>无论如何，翻译一定要结合游戏内实际情况进行二次验证，这能够提升自身的责任心。</li>
        <li>遇到难以理解的问题，尝试利用搜索引擎、游戏内测试、甚至询问他人来获得帮助。这将会大大提升自身的学习能力！</li>
        <li>无论用任何工具，翻译最终结果应当是读起来通顺易懂的，这能够提升自身的语文水平，同时理解中英文表达的不同。</li>
        <li>翻译请注意标点符号问题！</li>
        <li>遇到实在无法解决的翻译问题，不妨跳过不翻译它，做自己力所能及的才是最合适的。</li>
        <li>
          请再次确认你认真阅读了
          <a href="https://rules.cfpa.team/" class="url-info">翻译规范</a> 与
          <a href="https://weblate-guide.cfpa.team/" class="url-info">Weblate 使用说明</a>。
        </li>
        <li>很多作者的表达水平其实很差，因此部分翻译如果确实与实际不符，或者问题颇多，你完全可以用自己的话来表达出原意。但切勿过度发挥。</li>
        <li>翻译过程可能很不顺心，也可能会被他人指责。但请记住——“你需要聆听别人的意见，但绝不要在意他人的眼光”。</li>
      </ul>
    </div>

    <div>
      <h2 class="mt-5 text-3xl">我如何参与翻译</h2>
      <ul class="mt-2 list-inside list-disc text-lg text-gray-500 mb-5">
        <li>
          对于不懂模组语言文件机制的人，我们搭建的 weblate
          网站能够帮助小白快速上手参与翻译，你除了翻译本身不需要额外学习任何知识。
        </li>
        <li>weblate 是一个网站，你需要加群以后才能获取账户进入网站参与翻译。</li>
        <li>
          weblate
          的界面非常简单，上面是英文，下面是中文。翻译好了直接保存，如此逐条翻译完毕整个模组。
        </li>
        <li>加入群以后，请阅读群公告。</li>
        <li>
          申请账户找群组管理员，说明自己是否认真阅读了 weblate
          使用说明和翻译规范，同时提供一个邮箱号和你想要的用户名，审核通过后即可参与翻译。
        </li>
        <li>
          当然，你也可以直接通过
          <a href="https://ticket.cyllive.cn/" class="url-info">问题反馈中心</a>
          提交你自己翻译的语言文件，我们也会将其放入仓库中。
        </li>
        <li>
          如果你是一个翻译的老手，而且会用 GitHub，我们提供了
          <a
            href="https://github.com/CFPAOrg/Minecraft-Mod-Language-Package"
            class="url-info"
          >汉化项目的仓库</a>，提交 Pull Request 即可。
        </li>
      </ul>
    </div>

    <div>
      <h2 class="mt-5 text-3xl">鸣谢</h2>
      <ul class="list-inside list-disc mt-2 text-lg text-gray-500 mb-5">
        <li>感谢 phi 搭建出了 weblate 服务器，还实现了机翻功能；</li>
        <li>感谢 Summpot，Nullpinter 制作了新版本的 C# 爬虫；</li>
        <li>感谢 PeakXing 制作的 logo；</li>
        <li>感谢 雪尼、FledgeXu、asdflj 等在内的诸多人的意见和建议；</li>
        <li>
          感谢本项目的最初贡献者
          Aemande123，DYColdWind，Snownee，yuanjie000，forestbat，3TUSK，SihenZhang，MoXiaoFreak，gloomy_banana，yuanjie000，exia00125，luckyu19
          （排名不分先后）提供的汉化；
        </li>
        <li>感谢玩家 R_liu 提供的拔刀剑本地化；</li>
        <li>资源包中镶嵌了 3TUSK 提供的全角标点修复文件；</li>
        <li>感谢在汉化更新模组制作过程中提供了大量帮助的 Jack，某昨P 和 Towdium；</li>
        <li>最后感谢那些参与翻译，并致力于本地化推广的各位玩家，你们辛苦了。</li>
      </ul>
    </div>

    <button
      id="show"
      type="button"
      class="bg-indigo-500 shadow-lg hover:shadow-xl text-white text-center w-full text-lg rounded-md outline-none focus:outline-none py-1 mb-20 transition-all duration-150"
      @click="isShow = !isShow"
    >我读完了，给我显示群号！</button>
  </div>

  <div class="row container mx-auto md:w-2/4 w-11/12 md:flex justify-center" v-show="isShow">
    <div class="w-2/5 col-span-8 info-div mr-3">
      <img
        src="https://i.loli.net/2018/07/01/5b38b7eeb750a.png"
        alt="qq"
        class="img-fluid float-left"
      />
      <div class="info-text">
        <p class="text-white text-center font-bold info-title">通过 QQ 加入我们</p>
        <button
          type="button"
          class="bg-gray-50 py-1 join-us rounded-lg px-1 outline-none focus:outline-none"
          onclick="location.href='http://qm.qq.com/cgi-bin/qm/qr?k=YsUvyHx72I7b6KD6l3578PpGDvd86oE5'"
        >
          点击加群
          <br />（群号：630943368）
        </button>
      </div>
    </div>
    <div class="w-2/5 col-span-8 info-div ml-3">
      <img
        src="https://i.loli.net/2018/07/01/5b38b7eed09ee.png"
        alt="discord"
        class="img-fluid float-right"
      />
      <div class="info-text">
        <p class="text-white text-center font-bold info-title">通过 Discord 加入我们</p>
        <button
          type="button"
          class="bg-gray-50 py-1 rounded-lg join-us px-2 outline-none focus:outline-none"
          onclick="location.href='https://discord.gg/SGve5Fn'"
        >点击加群</button>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
  .row {
    margin-top: 1rem;
    padding: 0.8rem 0 0.8rem 0;
  }

  .main-title {
    margin-top: 1rem;
    margin-bottom: 1.5rem;
  }

  .join-us {
    margin: 0px auto;
    display: table;
  }

  .sub-info {
    margin-top: 1rem;
    margin-bottom: 4rem;
    padding: 1rem;
  }

  .footer {
    padding-top: 1rem;
    padding-bottom: 1rem;
  }

  .col-md-3,
  .col-sm-6 {
    padding: 1.5rem;
    margin-top: 1rem;
  }

  a,
  a:hover {
    color: darkslategray;
    text-decoration: none;
  }

  .col-md-3:hover,
  .col-xs-6:hover {
    background-color: #f2f1f1;
    border-radius: 0.2rem;
    transition-duration: 0.3s;
  }

  .info-div {
    margin-top: 0.5rem;
    margin-bottom: 0.5rem;
    margin-left: 0.5rem;
    margin-right: 0.5rem;
    background-color: #5c5c5c;
    padding: 1rem;
    border-radius: 0.5rem;
  }

  .info-text {
    margin-left: 0.5rem;
    margin-right: 0.5rem;
  }

  .text-muted {
    margin-top: 0.4rem;
    margin-bottom: 0.4rem;
  }

  #info-row {
    -o-justify-content: center;
    -webkit-justify-content: center;
    justify-content: center;
    display: none;
  }

  .info-title {
    margin-top: 0.5rem;
    margin-bottom: 1rem;
  }

  .url-info {
    color: brown;
    text-decoration: underline;
  }
</style>

<script lang="ts">
  import { Options, Vue } from "vue-class-component";

  @Options({})
  export default class Welcome extends Vue {
    isShow = false;
  }
</script>