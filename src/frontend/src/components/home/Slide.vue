<template>
  <div class="slide">
    <ul class="list">
      <li class="item">
        <img src="https://i.loli.net/2018/07/30/5b5e8d4b8bd1f.png" alt="pic" />
      </li>
      <li class="item">
        <img src="https://i.loli.net/2018/07/30/5b5e96a25925b.png" alt="pic" />
      </li>
      <li class="item">
        <img src="https://i.loli.net/2018/07/30/5b5e98dc33fe1.png" alt="pic" />
      </li>
      <li class="item">
        <img src="https://i.loli.net/2018/07/30/5b5e8d4b8bd1f.png" alt="pic" />
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
  import { Options, Vue } from 'vue-class-component'
  @Options({})
  export default class Slide extends Vue { }
</script>

<style>
  :root {
    --width: 635px;
    --height: 317.5px;
  }
  div.slide {
    width: var(--width);
    height: var(--height);
    overflow: hidden;

    /* 给input做定位参考 */
    position: relative;
  }
  ul.list {
    width: calc(var(--width) * 4);
    height: inherit;
    /* border: .5rem dashed blue; */
    position: relative;
    z-index: -1;
    animation: move 15s ease 1s infinite;
  }
  @keyframes move {
    0% {
      transform: translate(calc(0 * var(--width)));
    }
    33% {
      transform: translate(calc(-1 * var(--width)));
    }
    66% {
      transform: translate(calc(-2 * var(--width)));
    }
    100% {
      transform: translate(calc(-3 * var(--width)));
    }
  }
  li.item {
    width: var(--width);
    height: inherit;
    line-height: var(--height);
    float: left;
  }
  .slide:hover .labels {
    display: flex;
  }
  .slide:hover {
    cursor: pointer;
  }
</style>