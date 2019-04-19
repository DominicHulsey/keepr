<template>
  <!-- <div :class="$mq | mq({xxs: 'col-12 p-0',xs: 'col-12 p-0', sm: 'col-12 p-1', md: 'col-6 p-1', lg: 'col-6 p-1'})"> -->
  <div>
    <waterfall :line-gap="300" align="center" :watch="this.keeps" style="max-height:100%;">
      <!-- each component is wrapped by a waterfall slot -->
      <waterfall-slot v-for="(keep, index) in keeps" move-class="item-move1" v-if="keep.width" :width="keep.width"
        :height="keep.height" class="anim p-1" :order="keep.id" :key="keep.id">
        <keep-details :keep="keep"></keep-details>
        <drag :transfer-data="keep" class="keepClass">
          <img data-toggle="modal" @click="addCount(keep, 'views')" :data-target="'#Modal' + keep.id" class="keepImage"
            :index="keep.id" :src="keep.img">
          <div class="overlay" data-toggle="modal" @click="addCount(keep, 'views')" :data-target="'#Modal' + keep.id"
            :index="keep.id">
            <div class="row">
              <div class="col-6">
                <div class="mt-1">
                  <i class="fas fa-eye fa-2x"></i>
                  <p class="text-white" style="font-weight:bolder;">{{keep.views}}</p>
                </div>
              </div>
              <div class="col-6">
                <div class="mt-1">
                  <i class="fas fa-praying-hands fa-2x"></i>
                  <p class="text-white" style="font-weight:bolder;"> {{keep.keeps}}</p>
                </div>
              </div>
            </div>
          </div>
          <div class="overlay2" data-toggle="modal" @click="addCount(keep, 'views')" :data-target="'#Modal' + keep.id"
            :index="keep.id">
            <p class="text">{{keep.name}}</p>
          </div>
        </drag>
      </waterfall-slot>
    </waterfall>
  </div>
</template>


<script>
  import { Drag, Drop } from 'vue-drag-drop';
  import Waterfall from 'vue-waterfall/lib/waterfall';
  import WaterfallSlot from 'vue-waterfall/lib/waterfall-slot';
  import KeepDetails from '/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepDetails.vue'
  export default {
    name: 'keepTemplate',
    props: ["imageIndex"],
    mounted() {
    },
    data() {
      return {
        showDetails: false,
        waterfallOrder: this.$store.state.keeps.map(keep => keep.id)
      }
    },
    computed: {
      imageData() {
        let imgArray = this.images.map(image => {
          return image.image
        })
        let newArray = this.$store.state.keeps.filter(keep => {
          if (imgArray.includes(keep.img)) {
            return keep
          }
        })
        return newArray
      },
      keeps() {
        return this.$store.getters.keeps
      }
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      },
      myListener(wassup) {
        console.log("dragging")
      },
      addCount(keep, toAdd) {
        let payload = {
          keepData: keep,
          choice: toAdd
        }
        this.$store.dispatch("addCount", payload)
      }
    },
    components: {
      Drag,
      Drop,
      Waterfall,
      WaterfallSlot,
      KeepDetails
    }
  }
</script>


<style scoped>
  #keepButtons {
    transition: all 0.1s linear;
  }

  #keepButtons:hover {
    box-shadow: 1px 1px 2px black;
    background-color: #60a7f4 !important;
    transform: scale(1.02);
    cursor: pointer;
  }

  .sizing {
    max-width: 100%;
  }

  .item-move {
    transition: all 2s cubic-bezier(.55, 0, .1, 1) !important;
  }

  .item-move1 {
    transition: ease-in 2s all
  }

  #keepButtons:active {
    box-shadow: none;
    background-color: #007bff !important;
    transform: scale(1.01);
  }

  .bg-color {
    background-color: black;
  }

  .anim {
    /* box-shadow: -5px 5px 5px 0px rgba(152, 84, 187, 1) !important; */
    transition: .5s cubic-bezier(.55, 0, .1, 1);
  }

  .vue-waterfall {
    overflow: visible !important
  }

  .keepClass {
    position: relative;
    width: 100%;
  }

  .keepImage {
    display: block;
    width: 100%;
    height: auto;
  }

  .keepImage:hover {
    display: block;
    width: 100%;
    height: auto;
    cursor: pointer;
  }

  .text {
    color: white;
    font-size: 15px;
    position: absolute;
    top: 40%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
  }

  .text2 {
    color: white;
    font-size: 15px;
    position: absolute;
    top: 60%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
  }

  .overlay {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: #9854bb;
    overflow: hidden;
    width: 100%;
    height: 0;
    transition: .5s ease;
  }

  .overlay2 {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    background-color: rgba(128, 128, 128, 0.441);
    overflow: hidden;
    width: 100%;
    height: 0;
    transition: .5s ease;
  }

  .keepClass:hover .overlay2 {
    height: 65%;
    cursor: pointer;
  }

  .keepClass:hover .overlay {
    height: 35%;
    cursor: pointer;
  }
</style>