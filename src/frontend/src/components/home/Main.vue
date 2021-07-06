<template>
  <div class="container mx-auto md:w-8/12 w-11/12">
    <div class="md:flex">
      <Slide class="rounded-md" />
    </div>
  </div>
</template>

<script lang="ts">
  import { Options, Vue } from 'vue-class-component';
  import Slide from './Slide.vue';

  @Options({
    components: { Slide }
  })
  export default class Main extends Vue { }
</script>